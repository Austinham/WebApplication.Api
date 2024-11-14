using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IDbService _dbService;
    
    public AuthController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpGet("Login")]
    public IActionResult Login() {
        return Ok(new {meddelande = "Authorized"});
    }

    [HttpGet("Logout")]
    public IActionResult Logout() {
        return Ok(new {meddelande = "Logout"});
    }

    [HttpPost("RegisterSensorData")]
    public async Task<IActionResult> Register(Sensor sensor)
    {
        var rows = await _dbService.SaveDataPoint(sensor);
        
        return Ok(rows);
    }
}

public class Sensor
{
    public string SensorId {get; set; }
    public int Temp { get; set; }
    public int RHI { get; set; }
}