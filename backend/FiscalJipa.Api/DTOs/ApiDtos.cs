namespace FiscalJipa.Api.DTOs;

public sealed record PagedResult<T>(IReadOnlyList<T> Items, int Page, int PageSize, long TotalItems)
{
    public int TotalPages => PageSize <= 0 ? 0 : (int)Math.Ceiling((double)TotalItems / PageSize);
}

public sealed record ContratoCardDto(
    int Id,
    string NumeroContratoPncp,
    string? FornecedorNome,
    string? CnpjFornecedor,
    string? ObjetoDescricao,
    string? DepartamentoResponsavel,
    string? CategoriaNome,
    string? NomeOrgao,
    DateTime? DataVigenciaInicio,
    DateTime? DataVigenciaFim,
    int DiasParaVencer,
    decimal ValorTotal,
    decimal ValorPago,
    decimal SaldoRemanescente,
    decimal PercentualProgresso,
    bool Ativo,
    bool Aditivado,
    string StatusVisual,
    string StatusTexto);

public sealed record PagamentoDto(
    int Id,
    string? IdPagamentoPncp,
    DateTime? DataPagamento,
    decimal ValorPago,
    string? ChaveNfe,
    string? Descricao,
    string Tipo);

public sealed record ContratoDetailDto(
    int Id,
    string NumeroContratoPncp,
    string? FornecedorNome,
    string? CnpjFornecedor,
    string? ObjetoDescricao,
    string? DepartamentoResponsavel,
    string? CategoriaNome,
    string? NomeOrgao,
    DateTime? DataVigenciaInicio,
    DateTime? DataVigenciaFim,
    int DiasParaVencer,
    decimal ValorTotal,
    decimal ValorPago,
    decimal SaldoRemanescente,
    decimal PercentualProgresso,
    bool Ativo,
    bool Aditivado,
    int NumRetificacoes,
    DateTime? DataUltimaAtualizacaoPncp,
    IReadOnlyList<PagamentoDto> Pagamentos);

public sealed record SaldoDto(
    int ContratoId,
    decimal ValorTotal,
    decimal ValorPago,
    decimal Saldo,
    bool Aditivado,
    int NumAditivos);

public sealed record DashboardResumoDto(
    long TotalContratos,
    decimal ValorTotalEmpenho,
    decimal ValorTotalLiquidado,
    decimal PercentualExecucao,
    long TotalFornecedores,
    long TotalOrgaos,
    DateTimeOffset? UltimaAtualizacao);

public sealed record DashboardCategoriaDto(
    int CategoriaId,
    string NomeCategoria,
    string? CorBadge,
    string? Icone,
    long QuantidadeContratos,
    decimal ValorTotal,
    decimal PercentualDoTotal);

public sealed record DashboardFornecedorDto(
    string? CnpjFornecedor,
    string? FornecedorNome,
    long QuantidadeContratos,
    decimal ValorTotalContratos,
    decimal PercentualDoTotal,
    string? NomeOrgao);

public sealed record DashboardTimelineDto(
    string Mes,
    string MesFormatado,
    long QuantidadeContratos,
    decimal ValorTotal,
    decimal ValorPago);

public sealed record HealthCheckDto(
    string Status,
    DateTimeOffset Timestamp,
    string Database);

public sealed record SincronizacaoResumoDto(
    int Id,
    string NomeOrgao,
    string TipoSincronizacao,
    string Status,
    DateTime? DataInicioSincronizacao,
    DateTime? DataFimSincronizacao,
    int TotalContratos,
    int TotalPagamentos,
    string? MensagemErro,
    string? DataFormatada);

public sealed record SyncExecutionDto(
    DateTimeOffset ExecutadoEm,
    bool Sucesso,
    int TotalOrgaos,
    int TotalContratos,
    int TotalPagamentos,
    int TotalErros,
    string Mensagem);
