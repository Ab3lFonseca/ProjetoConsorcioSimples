using Infrastructure.DataBase;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

public class DataBaseContext : IDbContext
{
    private readonly string _connectionString;

    public DataBaseContext(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("ConhecimentoConsorcio");
    }

    public IDbConnection CreateConnection()
    {
        return new MySqlConnection(_connectionString);
    }
}
