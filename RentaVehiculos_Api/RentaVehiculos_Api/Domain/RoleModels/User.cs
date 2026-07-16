namespace RentaVehiculos_Api.Domain.RoleModels
{
    public class User
    {
        public int UsuarioId { get; set; }
        public string? Name { get; set; }
        public string? pass { get; set; }
        public DateTime FechaCreacion { get; set; }


        public override string ToString()
        {
            return $"{UsuarioId},{Name}";
        }
    }
}
