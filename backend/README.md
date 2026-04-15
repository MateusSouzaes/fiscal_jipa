# FISCAL JIPA - Backend API

API REST para transparência ativa em contratos públicos via PNCP.

## 📋 Descrição

Backend da plataforma **Fiscal Jipa** desenvolvido em **C# .NET 8** com foco em:
- Integração com API PNCP (Portal Nacional de Contratações Públicas)
- Busca inteligente por termos em linguagem natural
- Dashboards financeiros em tempo real
- Auditoria completa de operações
- Sincronização automática diária

## 🏗️ Arquitetura

### Estrutura de Diretórios

```
FiscalJipa.Api/
├── Controllers/           # Endpoints REST
├── Services/              # Lógica de negócio
├── Models/                # Entidades de domínio
├── Data/                  # EF Core DbContext
├── DTOs/                  # Data Transfer Objects
├── Exceptions/            # Custom exceptions
├── Program.cs             # Startup e DI
└── appsettings.json       # Configuração
```

## 🚀 Começando

### Pré-requisitos

- .NET 8 SDK
- MySQL 8.0+
- Node.js 20 LTS (para frontend)

### Instalação

1. Clone o repositório
```bash
git clone https://github.com/seu-usuario/fiscal-jipa.git
cd fiscal-jipa/backend
```

2. Configure as variáveis de ambiente (`.env` ou `appsettings.Development.json`)
```json
{
  "ConnectionStrings": {
    "MySql": "Server=localhost;Port=3306;Database=fiscal_jipa;User=root;Password=senha"
  },
  "PNCP_BASE_URL": "https://pncp.gov.br/api/consulta",
  "PNCP_TIMEOUT_SECONDS": "30"
}
```

3. Instale dependências e rode migrations
```bash
dotnet restore
dotnet ef database update
```

4. Inicie a aplicação
```bash
dotnet run
```

API estará disponível em: `http://localhost:5000`

### Swagger/API Docs

Acesse a documentação interativa em: `http://localhost:5000/swagger`

## 📡 Endpoints Principais

### Contratos
```
GET    /api/v1/contratos?pagina=1&tamanho=20     # Listar com paginação
GET    /api/v1/contratos/{id}                     # Obter detalhes
GET    /api/v1/contratos/{id}/saldo               # Obter saldo
GET    /api/v1/contratos/ativos                   # Apenas ativos
```

### Dashboard
```
GET    /api/v1/dashboard/resumo                   # KPIs gerais
GET    /api/v1/dashboard/gastos-por-mes           # Timeline
GET    /api/v1/dashboard/categorias               # Por categoria
GET    /api/v1/dashboard/top-fornecedores         # Top 5
```

### Saúde
```
GET    /api/health                                # Status da API
```

## 📊 Stack Tecnológico

| Camada | Tecnologia | Versão |
|--------|-----------|--------|
| **Runtime** | .NET | 8.0 LTS |
| **Web** | ASP.NET Core | 8.0 |
| **ORM** | Entity Framework Core | 8.0.13 |
| **Database** | MySQL | 8.0+ |
| **Docs** | Swagger/OpenAPI | 6.6.2 |
| **MySQL Driver** | Pomelo | 8.0.3 |

## 🔐 Segurança

- ✅ JWT para autenticação (planejado v2)
- ✅ CORS configurado para frontend
- ✅ Connection pooling otimizado
- ✅ Logs estruturados em JSON

## 🧪 Testes

### Rodando testes unitários
```bash
cd ../FiscalJipa.Api.Tests
dotnet test
```

## 📝 Padrões de Código

### Nomenclatura

| Tipo | Padrão | Exemplo |
|------|--------|---------|
| **Namespaces** | `FiscalJipa.Api.{Categoria}` | `FiscalJipa.Api.Controllers` |
| **Classes** | PascalCase | `ContratoService` |
| **Métodos** | PascalCase + Async | `ObterPorIdAsync()` |
| **DTOs** | Entity + Suffix | `ContratoCardDto`, `ContratoDetailDto` |
| **BD Tabelas** | snake_case | `contratos`, `categorias_gasto` |

### Padrões de Design

- **Dependency Injection**: Services registrados no `Program.cs`
- **Repository Pattern**: Via EF Core DbContext
- **DTO Pattern**: DTOs para input/output isolam models de domínio
- **Async/Await**: Todas operações I/O são assíncronas

## 📦 Dependências Principais

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.13" />
<PackageReference Include="Pomelo.EntityFrameworkCore.MySql" Version="8.0.3" />
<PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="8.0.25" />
<PackageReference Include="Swashbuckle.AspNetCore" Version="6.6.2" />
```

## 📊 Modelo de Dados

### Tabelas Principais

- **contratos**: Contratos públicos (central)
- **pagamentos**: Pagamentos associados aos contratos
- **categorias_gasto**: Categorização automática
- **usuarios**: Usuários e RBAC (planejado v2)
- **auditoria_acoes**: Log de operações

Mais detalhes em `.atividades/ESPECIFICACAO_API_FISCAL_SIMPLIFICADA.md`

## 🤝 Contribuindo

1. Crie um branch para sua feature (`git checkout -b feature/nome`)
2. Commit suas mudanças (`git commit -am 'feat: descricao'`)
3. Push para o branch (`git push origin feature/nome`)
4. Abra um Pull Request

## 📝 Licença

Este projeto é desenvolvido como atividade acadêmica.

---

**Autor**: Mateus Souza  
**Disciplina**: Programação Back-End Avançada  
**Período**: 6º Período - 2026  
**Instituição**: IFRO - Universidade Federal de Rondônia
