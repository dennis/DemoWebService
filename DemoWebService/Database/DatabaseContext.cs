using MySql.Data.MySqlClient;

using System.Data;

namespace DemoWebService.Database;

public class DatabaseContext
{
    private readonly string _connectionString;

    public DatabaseContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("SqlConnection");
    }

    public IDbConnection CreateConnection()
        => new MySqlConnection(_connectionString);
}
