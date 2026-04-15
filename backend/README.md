# FISCAL JIPA: API REST PARA TRANSPARÊNCIA ATIVA EM CONTRATOS PÚBLICOS VIA PNCP

**Instituto Federal de Educação, Ciência e Tecnologia de Rondônia – IFRO**  
Campus Ji-Paraná  
Curso Superior de Tecnologia em Análise e Desenvolvimento de Sistemas

**Autor**: Mateus Souza e Silva  
**Professor**: João Eujácio Teixeira Júnior  
**Período**: 6º Período - 2026

---

## 1. DESCRIÇÃO DO PRODUTO

O **FISCAL JIPA** é uma API REST desenvolvida para promover transparência ativa, integrando e processando dados do Portal Nacional de Contratações Públicas (PNCP). O sistema permite monitoramento de contratos públicos através de buscas otimizadas em linguagem natural, geração de indicadores financeiros e sistema de alertas automatizados.

### 1.1 Principais Funcionalidades

- ✅ Busca semântica e filtros de contratos **sem exigência de autenticação**
- ✅ Sincronização **diária automatizada** com API governamental PNCP
- ✅ Dashboards financeiros (KPIs, gastos mensais, top fornecedores)
- ✅ Motor de **categorização automática** de despesas
- ✅ **Log de auditoria integral** para rastreabilidade de ações

---

## 2. REQUISITOS PRIMÁRIOS

### 2.1 Requisitos Funcionais

| ID | Descrição |
|---|---|
| **RF-01** | Visualizar e buscar contratos por termos populares sem autenticação |
| **RF-02** | Sincronizar dados automaticamente com API do PNCP |
| **RF-03** | Gerar dashboard com indicadores (Total, Saldo, Categorias) |
| **RF-04** | Implementar controle de acesso (RBAC - 5 níveis) |
| **RF-05** | Emitir alertas de contratos próximos a vencer ou saldo zero |
| **RF-06** | Manter registro imutável de auditoria de operações críticas |

### 2.2 Requisitos Não-Funcionais

| ID | Descrição | Critério |
|---|---|---|
| **RNF-01** | Performance requisições | < 300ms |
| **RNF-02** | Performance buscas full-text | < 200ms |
| **RNF-03** | Disponibilidade | 99% uptime |
| **RNF-04** | Design responsivo mobile-first | 80% mobile |
| **RNF-05** | Segurança JWT + HTTPS | Padrão |

---

## 3. STACK TECNOLÓGICO

| Camada | Tecnologia | Versão |
|--------|-----------|--------|
| **Runtime** | .NET | 8.0 LTS |
| **Web** | ASP.NET Core | 8.0 |
| **ORM** | Entity Framework Core | 8.0.13 |
| **Banco** | MySQL | 8.0+ |
| **Docs API** | Swagger/OpenAPI | 6.6.2 |

---

## 4. ARQUITETURA

### 4.1 Estrutura de Diretórios

```
FiscalJipa.Api/
├── Controllers/           # Endpoints REST
├── Services/              # Lógica de negócio
├── Models/                # Entidades de domínio
├── Data/                  # EF Core DbContext
├── DTOs/                  # Data Transfer Objects
├── Program.cs             # Startup e DI
└── appsettings.json       # Configuração
```

### 4.2 Padrões de Arquitetura

- **Dependency Injection**: Services registrados no `Program.cs`
- **Repository Pattern**: Via Entity Framework Core
- **DTO Pattern**: Isolamento entre modelos de domínio e API
- **Async/Await**: Todas operações I/O assíncronas

---

## 5. ENDPOINTS PRINCIPAIS

### Contratos
```
GET    /api/v1/contratos?pagina=1&tamanho=20     Listar com paginação
GET    /api/v1/contratos/{id}                     Obter detalhes
GET    /api/v1/contratos/{id}/saldo               Obter saldo
GET    /api/v1/contratos/ativos                   Apenas ativos
```

### Dashboard
```
GET    /api/v1/dashboard/resumo                   KPIs gerais
GET    /api/v1/dashboard/gastos-por-mes           Timeline
GET    /api/v1/dashboard/categorias               Por categoria
GET    /api/v1/dashboard/top-fornecedores         Top 5
```

### Sistema
```
GET    /api/health                                Status da API
```

---

## 6. COMEÇANDO

### 6.1 Pré-requisitos

- .NET 8 SDK
- MySQL 8.0+
- Visual Studio Code ou Visual Studio

### 6.2 Instalação

```bash
# Clonar repositório
git clone https://github.com/MateusSouzaes/fiscal_jipa.git
cd fiscal_jipa/backend

# Restaurar dependências
dotnet restore

# Executar migrations
dotnet ef database update

# Iniciar aplicação
dotnet run
```

### 6.3 Acessar API

- **API**: http://localhost:5000
- **Swagger**: http://localhost:5000/swagger

---

## 7. CONFIGURAÇÃO

Criar arquivo `.env` ou `appsettings.Development.json`:

```json
{
  "ConnectionStrings": {
    "MySql": "Server=localhost;Port=3306;Database=fiscal_jipa;User=root;Password=senha"
  },
  "PNCP_BASE_URL": "https://pncp.gov.br/api/consulta",
  "PNCP_TIMEOUT_SECONDS": "30"
}
```

---

## 8. TESTES

```bash
# Executar testes unitários
cd ../FiscalJipa.Api.Tests
dotnet test
```

---

## 9. MODELO DE DADOS

### Tabelas Principais

| Tabela | Descrição |
|--------|-----------|
| **contratos** | Contratos públicos (central) |
| **pagamentos** | Pagamentos associados |
| **categorias_gasto** | Categorização automática |
| **usuarios** | Usuários e RBAC |
| **auditoria_acoes** | Log de operações |

Detalhes: Ver `.atividades/ESPECIFICACAO_API_FISCAL_SIMPLIFICADA.md`

---

## 10. PADRÕES DE CÓDIGO

| Tipo | Padrão | Exemplo |
|------|--------|---------|
| **Namespaces** | `FiscalJipa.Api.{Categoria}` | `FiscalJipa.Api.Controllers` |
| **Classes** | PascalCase | `ContratoService` |
| **Métodos** | PascalCase + Async | `ObterPorIdAsync()` |
| **DTOs** | Entity + Suffix | `ContratoCardDto` |
| **BD Tabelas** | snake_case | `contratos` |

---

## 11. REFERÊNCIAS E LINKS

- [Especificação Completa](../.atividades/ESPECIFICACAO_API_FISCAL_SIMPLIFICADA.md)
- [Documentação da API](http://localhost:5000/swagger)
- [Portal PNCP](https://pncp.gov.br/)
- [.NET 8 Docs](https://learn.microsoft.com/en-us/dotnet/)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)

---

**Edition**: 1.0  
**Data**: Abril de 2026  
**Status**: Desenvolvimento
