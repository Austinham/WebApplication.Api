using WebApplication.Api.Controllers;

namespace WebApplication.Api;

public interface IDbService
{
    public Task<string> SaveDataPoint(Sensor sensor);
    public void PrintInfo();
}