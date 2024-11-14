using Npgsql;
using WebApplication.Api.Controllers;

namespace WebApplication.Api;

public class DbService : IDbService
{
    private readonly string? _connectionString;

    public DbService(IConfiguration configuration)
    {
        _connectionString = configuration["ConnectionStrings:PostgreSQL"];
    }
    
    public async Task<string> SaveDataPoint(Sensor sensor)
    {
        int rows = 0;

        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString)) {
            await connection.OpenAsync();

            using (NpgsqlCommand command = new NpgsqlCommand("INSERT INTO sensordata (sensorid, temp, rhi) VALUES (@sensor, @temp, @rhi)", connection)) {
                command.Parameters.AddWithValue("@sensor", sensor.SensorId);
                command.Parameters.AddWithValue("@temp", sensor.Temp);
                command.Parameters.AddWithValue("@rhi", sensor.RHI);

                rows = await command.ExecuteNonQueryAsync();
            }
        }
        return rows.ToString();
    }

    public void PrintInfo()
    {
        throw new NotImplementedException();
    }
}