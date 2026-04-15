using FiscalJipa.Api.DTOs;
using FiscalJipa.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace FiscalJipa.Api.Controllers;

/// <summary>
/// Gerencia operações com contratos públicos
/// </summary>
[ApiController]
[Route("api/v1/contratos")]
[Produces("application/json")]
public class ContratosController : ControllerBase
{
    private readonly IContratoService _contratoService;

    public ContratosController(IContratoService contratoService)
    {
        _contratoService = contratoService;
    }

    /// <summary>
    /// Lista contratos com paginação
    /// </summary>
    /// <remarks>
    /// Retorna contratos com informações básicas (número, fornecedor, valor, período).
    /// Suporta filtro por termo, órgão e status.
    /// </remarks>
    [HttpGet]
    [ProduceResponseType(StatusCodes.Status200OK)]
    [ProduceResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PagedResult<ContratoCardDto>>> ListarAsync(
        [FromQuery] int pagina = 1,
        [FromQuery] int tamanho = 20,
        [FromQuery] string? termo = null,
        [FromQuery] int? orgaoId = null,
        [FromQuery] bool? somenteAtivos = null,
        CancellationToken cancellationToken = default)
    {
        var resultado = await _contratoService.ObterPaginaAsync(pagina, tamanho, termo, orgaoId, somenteAtivos, cancellationToken);
        return Ok(resultado);
    }

    [HttpGet("{id:int}")]
    [ProduceResponseType(StatusCodes.Status200OK)]
    [ProduceResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ContratoDetailDto>> ObterPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var contrato = await _contratoService.ObterPorIdAsync(id, cancellationToken);
        return contrato is null ? NotFound() : Ok(contrato);
    }

    /// <summary>
    /// Obtém o saldo remanescente de um contrato
    /// </summary>
    [HttpGet("{id:int}/saldo")]
    [ProduceResponseType(StatusCodes.Status200OK)]
    [ProduceResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SaldoDto>> ObterSaldoAsync(int id, CancellationToken cancellationToken = default)
    {
        var saldo = await _contratoService.ObterSaldoAsync(id, cancellationToken);
        return saldo is null ? NotFound() : Ok(saldo);
    }

    /// <summary>
    /// Lista apenas contratos em vigência
    /// </summary>
    [HttpGet("ativos")]
    [ProduceResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<ContratoCardDto>>> ObterAtivosAsync(CancellationToken cancellationToken = default)
    {
        var contratos = await _contratoService.ObterAtivosAsync(cancellationToken);
        return Ok(contratos);
    }
}
