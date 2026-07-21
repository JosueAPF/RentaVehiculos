using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RentaVehiculos_Api.Aplication.Helpers;
using RentaVehiculos_Api.Aplication.Interfaces;
using RentaVehiculos_Api.Aplication.Services;
using RentaVehiculos_Api.Infraestructure.Data;
using RentaVehiculos_Api.Infraestructure.Interfaces;
using RentaVehiculos_Api.Infraestructure.Repository;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Data acces 
builder.Services.AddScoped<DataAcces>();
//Repositorys
builder.Services.AddScoped<IRepository, ClienteRepository>();//clientes
builder.Services.AddScoped<IVehiculosRopository,VehiculosRepository>(); //vehiculos
builder.Services.AddScoped<IRentaRepository, RentaRepository>();//rentas
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();//jwt
builder.Services.AddScoped<AuthService>();//authentificacion usuario permiso roles
//Services's
builder.Services.AddScoped<IClientesServices, ClientesServices>();
builder.Services.AddScoped<IVehiculoServices, VehiculoServices>();
builder.Services.AddScoped<IRentaServicio,RentaServicio>();

//servicio de jwt
builder.Services.AddScoped<JwtHelper>();

//jwt
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    var jwt = builder.Configuration.GetSection("jwt");//jwt del appseting.json

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,

        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwt["Key"]!)
        ),
        RoleClaimType = ClaimTypes.Role,
        ValidIssuer = jwt["Issuer"],
        ValidAudience = jwt["Audience"],
      
    };
}); builder.Services.AddAuthorization();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//jwt swagger modificado
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Ingresa el token: Bearer {tu token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//activar el midleware de jwt
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
