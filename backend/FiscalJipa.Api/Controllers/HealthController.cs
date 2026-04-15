using FiscalJipa.Api.Data;
using FiscalJipa.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiscalJipa.Api.Controllers;

/// <summary>
/// Verificação de saúde da aplicação
/// </summary>
[ApiController]
[Route("api/health")]
[Produces("application/json")]
public class HealthController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public HealthController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Verifica status da aplicação e conexão com banco de dados
    /// </summary>
    [HttpGet]
    [ProduceResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<HealthCheckDto>> GetAsync(CancellationToken cancellationToken = default)
    {
        var canConnect = await _dbContext.Database.CanConnectAsync(cancellationToken);
        return Ok(new HealthCheckDto
        {
            Status = canConnect ? "healthy" : "degraded",
            Timestamp = DateTimeOffset.UtcNow,
            Database = canConnect ? "connected" : "unavailable"
        });
    }
}
