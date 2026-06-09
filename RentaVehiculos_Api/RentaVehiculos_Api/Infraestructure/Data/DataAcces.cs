using Microsoft.Data.SqlClient;

namespace RentaVehiculos_Api.Infraestructure.Data
{
    public class DataAcces
    {
        private readonly string _ConnectionString;

        public DataAcces(IConfiguration config)
        {
            _ConnectionString = config.GetConnectionString("DefaultConnection");
        }

        public SqlConnection GetConnection() {
            return new SqlConnection(_ConnectionString);
        }
    }
}
