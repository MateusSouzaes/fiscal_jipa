# 🏛️ Fiscal de Jipa v2.0 - Plataforma de Transparência Ativa

[![License](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![Status](https://img.shields.io/badge/Status-Desenvolvimento-yellow.svg)]()
[![Version](https://img.shields.io/badge/Version-2.0-green.svg)]()

**Fiscal de Jipa** é uma plataforma web de transparência ativa para a Câmara Municipal de Ji-Paraná que integra dados de contratos públicos (API PNCP) com dashboards financeiros, alertas inteligentes e RBAC completo (5 roles + 11 permissões).

---

## 🎯 Características Principais

- ✅ **Integração PNCP** - Sincronização automática diária de contratos públicos
- ✅ **Dashboard Financeiro** - Visualização em tempo real com gráficos e KPIs
- ✅ **RBAC v2.0** - 5 roles + 11 permissões granulares
- ✅ **Usuários Civis** - Suporte para usuários sem órgão vinculado
- ✅ **Alertas Inteligentes** - Saldo baixo, vencimento próximo, aditivos
- ✅ **Mobile-First** - Responsivo 320px-1920px
- ✅ **Integridade de Dados** - ON DELETE RESTRICT (sem cascata de deletes)

---

## 📋 Índice

1. [Estrutura do Projeto](#-estrutura-do-projeto-monolítico)
2. [Quick Start](#-quick-start)
3. [Pré-requisitos](#-pré-requisitos)
4. [Desenvolvimento](#-desenvolvimento)
5. [Documentação](#-documentação)
6. [Arquitetura](#-arquitetura)
7. [Deployment](#-deployment)
8. [Troubleshooting](#-troubleshooting)

---

## 🎯 Visão Geral

**Fiscal de Jipa** é uma plataforma web inovadora que:
- **Consome dados** da [API PNCP](https://pncp.gov.br/api/consulta) (Portal Nacional de Contratações Públicas)
- **Processa e armazena** informações de contratos localmente no MySQL
- **Exibe relatórios** em tempo real com gráficos interativos
- **Oferece busca** em linguagem popular (não técnica) para cidadãos
- **Mobile-first** — otimizada para smartphones

### Stacks Utilizadas:
| Componente | Tecnologia | Versão |
|-----------|-----------|---------|
| **Backend** | C# (.NET) | 8.0+ |
| **Frontend** | EJS + Node.js | 3.1 / 20 LTS |
| **Database** | MySQL | 8.0+ |
| **API Docs** | Swagger/OpenAPI | 3.0 |
| **Source Data** | PNCP API | v2.3.11 |

---

## 🔧 Pré-requisitos

Antes de começar, instale:

### Windows / macOS / Linux:

#### 1. **Node.js & npm**
```bash
# Download: https://nodejs.org/ (LTS 20+)
# Verificar instalação:
node --version   # v20.x.x
npm --version    # 10.x.x
```

#### 2. **.NET SDK 8.0+**
```bash
# Download: https://dotnet.microsoft.com/download/dotnet/8.0
# Verificar:
dotnet --version  # 8.x.x
```

#### 3. **MySQL 8.0+**
```bash
# Download: https://dev.mysql.com/downloads/mysql/
# Ou via Docker:
docker run --name mysql_fiscal -e MYSQL_ROOT_PASSWORD=root -p 3306:3306 -d mysql:8.0

# Verificar conexão:
mysql -h localhost -u root -p
```

#### 4. **Git**
```bash
git --version  # git version 2.x.x+
```

#### 5. **VS Code** (Recomendado)
```bash
# Download: https://code.visualstudio.com/
# Extensions recomendadas:
# - C# Dev Kit
# - EJS language support
# - MySQL Workbench
# - REST Client
```

---

## 🚀 Setup Local

### 1️⃣ Clone do Repositório

```bash
git clone https://github.com/your-org/fiscal-jipa.git
cd fiscal-jipa
```

### 2️⃣ Configurar Variáveis de Ambiente

```bash
cp .env.example .env
# Editar .env com valores locais
```

**Valores padrão para dev:**
```env
DB_HOST=localhost
DB_USER=root
DB_PASSWORD=root
ASPNETCORE_ENVIRONMENT=Development
```

### 3️⃣ Setup Database

#### Opção A: Via SQL Script Direto

```bash
# MySQL CLI
mysql -h localhost -u root -p < database/fiscal_jipa.sql

# Ou MySQL Workbench:
# 1. File → Open SQL Script
# 2. Selecionar fiscal_jipa.sql
# 3. Execute (Ctrl+Shift+Enter)
```

#### Opção B: Via Entity Framework (Não recomendado inicialmente)

```bash
cd backend
dotnet ef migrations add InitialCreate
dotnet ef database update
cd ..
```

📌 **Verificar:**
```sql
mysql> USE fiscal_jipa;
mysql> SHOW TABLES;
-- Deve exibir 10+ tabelas
```

### 4️⃣ Setup Backend (.NET)

```bash
cd backend

# Restaurar dependências NuGet
dotnet restore

# Build
dotnet build

# Run (com hot reload)
dotnet watch run --urls="http://localhost:5000"
```

✅ **Verificar:** Swagger deve estar em `http://localhost:5000/swagger`

### 5️⃣ Setup Frontend (Node.js)

Abrir novo terminal:

```bash
cd frontend

# Instalar dependências npm
npm install

# Run dev server
npm start
# ou: node app.js
```

✅ **Verificar:** `http://localhost:3000` deve exibir homepage

### 6️⃣ Testar Integração

```bash
# Terminal 1: Backend rodando em localhost:5000
# Terminal 2: Frontend rodando em localhost:3000

# Abrir browser:
http://localhost:3000

# Verificar:
# ✓ Homepage renderiza
# ✓ Swagger acessível em http://localhost:5000/swagger
# ✓ Console sem erros (F12)
```

---

## 📁 Estrutura do Projeto (Monolítico)

```
fiscal-jipa/                         # Raiz do projeto
│
├── src/                            # Código-fonte principal
│   ├── backend/                    # API C# .NET 8
│   │   ├── FiscalJipa.Api/
│   │   │   ├── Controllers/
│   │   │   ├── Services/
│   │   │   ├── Models/
│   │   │   ├── Data/
│   │   │   ├── Program.cs
│   │   │   └── appsettings.json
│   │   ├── FiscalJipa.Api.Tests/   # Testes da API
│   │   └── FiscalJipa.slnx
│   │
│   ├── frontend/                   # App Node.js + EJS
│   │   ├── views/                 # Templates EJS
│   │   ├── public/                # CSS, JS, imagens
│   │   ├── services/              # Backend API client
│   │   ├── routes.js
│   │   ├── app.js
│   │   └── package.json
│   │
│   └── shared/                     # Código compartilhado (DTOs, types)
│
├── db/                             # Banco de dados
│   ├── 01-schema.sql              # Schema MySQL (13 tabelas)
│   ├── 02-seed.sql                # Dados iniciais
│   ├── 03-procedures.sql          # Triggers e procedures
│   └── README.md
│
├── docs/                           # Documentação
│   ├── development/               # Guias de desenvolvimento (.claude/)
│   │   ├── INDEX.md               # Ponto de entrada
│   │   ├── ROTEIRO_EXECUCAO.md   # Roadmap 9 fases
│   │   ├── GUIDELINES_DESENVOLVIMENTO.md
│   │   └── CONSTRAINTS.md         # Regras de ouro
│   │
│   ├── schema/                    # Documentação do BD
│   │   ├── ESPECIFICACAO_SOFTWARE_MVP.md
│   │   └── SUMARIO_EXECUTIVO.md
│   │
│   └── API.md                     # Documentação de endpoints
│
├── tests/                          # Testes automatizados
│   ├── unit/                      # Testes unitários
│   ├── integration/               # Testes de integração
│   └── e2e/                       # Testes ponta a ponta (Cypress)
│
├── config/                         # Configurações
│   ├── appsettings.json           # Config Backend
│   ├── appsettings.Development.json
│   └── .env.example               # Template variáveis
│
├── scripts/                        # Scripts de automação
│   ├── deploy.sh                  # Deployment
│   ├── db-setup.sh                # Setup BD
│   └── sync-pncp.sh               # Sync manual
│
├── LEGADO/                         # 📦 Arquivos antigos (não usar)
│   ├── CLAUDE.md
│   ├── DELIVERY_SUMMARY.md
│   ├── DOCUMENTATION_INDEX.md
│   ├── ROADMAP.md
│   ├── PROJECT_CONTEXT.md
│   └── _PROJECT_STATUS.md
│
├── .env.example                    # Template de variáveis
├── .gitignore
├── package.json                    # Deps Node.js (raiz)
├── README.md                       # Este arquivo ⭐
└── .github/                        # CI/CD e templates
    ├── workflows/
    └── ISSUE_TEMPLATE/
```

**Ver também:** [Development Guide](docs/development/INDEX.md)

---

## 📚 Documentação Técnica

### Arquivos Principais:

1. **`CLAUDE.md`**  
   → Guia completo para AI agents (Akita pattern)  
   → Arquitetura, regras de negócio, convenções de código

2. **`ROADMAP.md`**  
   → Timeline 16 semanas em 8 fases  
   → Critérios de aceitação, KPIs, stakeholders

3. **`fiscal_jipa.sql`**  
   → Schema MySQL completo  
   → Tabelas, views, triggers, stored procedures, seeds

### Endpoint API (Backend):

```bash
# Contratos
GET    /api/contratos?pagina=1&tamanho=20
GET    /api/contratos/{id}
GET    /api/contratos/{id}/saldo
GET    /api/contratos/search?termo=asfalto

# Dashboard
GET    /api/dashboard/resumo
GET    /api/dashboard/gastos-mes
GET    /api/dashboard/categorias
GET    /api/dashboard/fornecedores

# Admin
POST   /api/admin/sync-pncp
GET    /api/admin/sync-history
GET    /api/admin/config

# Health
GET    /health
GET    /swagger
```

### Fluxo de Dados:

```
┌─────────────┐
│  PNCP API   │  https://pncp.gov.br/api/consulta
└──────┬──────┘
       │ GetContratosByCnpj()
       │ GetInstrumentosCobranca()
       ▼
┌─────────────────────────────────┐
│  Backend C# (SyncPNCPJob)       │
│  - Consume API PNCP             │
│  - Categorizacao automation     │
│  - Saldo calculation            │
└──────┬──────────────────────────┘
       │
       ▼
┌─────────────────────────────────┐
│  MySQL Database                 │
│  - contratos                    │
│  - pagamentos                   │
│  - categorias_populares         │
│  - sincronizacoes               │
└──────┬──────────────────────────┘
       │
       ▼
┌─────────────────────────────────┐
│  Frontend (EJS + Express)       │
│  - Busca full-text              │
│  - Dashboard com gráficos       │
│  - Card detail contracts        │
└─────────────────────────────────┘
```

---

## 💻 Desenvolvimento

### Comandos Úteis:

```bash
# Backend
cd backend
dotnet watch run                    # Hot reload
dotnet test                         # Run unit tests
dotnet publish -c Release           # Build production

# Frontend
cd frontend
npm start                           # Dev server
npm run build                       # Production build
npm test                           # Tests

# Database
mysql -u root -p fiscal_jipa < fiscal_jipa.sql   # Reset DB
```

### Git Workflow:

```bash
# Feature branch
git checkout -b feature/nova-funcionalidade
# ... editar arquivos ...
git add .
git commit -m "feat: descrição da feature"
git push origin feature/nova-funcionalidade
# Abrir Pull Request

# Merge após review
git checkout main
git merge feature/nova-funcionalidade
git push
```

### Code Style:

- **C#:** [Microsoft Naming Conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- **EJS:** [Airbnb HTML/CSS Style Guide](https://airbnb.io/projects/cpp-style-guide/)
- **SQL:** snake_case para tabelas/colunas

### Testing:

```bash
# Backend - xUnit
dotnet test backend/FiscalJipa.Tests.csproj

# Frontend - Cypress E2E
npx cypress open
# ou headless:
npm run test:e2e
```

---

## 🌐 Deployment

### Staging:

```bash
# Build Docker images
docker-compose build

# Run containers
docker-compose up -d

# Verificar
curl http://localhost:5000/health
curl http://localhost:3000
```

### Production:

1. **Escolher hosting:** Azure, AWS, DigitalOcean
2. **Configure CI/CD:** GitHub Actions ou Azure DevOps
3. **Deploy:** Kubernetes, App Service, ou Docker Compose
4. **SSL:** Let's Encrypt via Certbot
5. **Monitoring:** Azure Monitor, Datadog, ou New Relic
6. **Backup:** Daily snapshots do DB

Consulte `ROADMAP.md` Fase 7 para detalhes.

---

## 🐛 Troubleshooting

### Problema: "Cannot connect to database"

```bash
# Verificar MySQL está rodando
mysql -h localhost -u root -p -e "SELECT 1"

# Verificar connection string em .env
DB_HOST=localhost
DB_USER=root
DB_PASSWORD=root
```

### Problema: "Port 3306 already in use"

```bash
# Windows
netstat -ano | findstr :3306
taskkill /PID <PID> /F

# macOS/Linux
lsof -i :3306
kill -9 <PID>
```

### Problema: "PNCP API timeout"

- Aumentar `PNCP_TIMEOUT_SECONDS` em `.env`
- Verificar firewall/proxy
- Consultar status PNCP: https://pncp.gov.br

### Problema: "Frontend não conecta ao backend"

```bash
# Verificar CORS está habilitado no Program.cs
builder.Services.AddCors(options => 
    options.AddDefaultPolicy(b => b.AllowAnyOrigin())
);

# Verificar URL no frontend (.env):
BACKEND_URL=http://localhost:5000
```

### Problema: "Swagger retorna 404"

- Verificar `EnableSwagger()` em `Program.cs`
- Acessar: `http://localhost:5000/swagger/index.html`

---

## 📞 Suporte & Contribuições

- **Reported Issues:** GitHub Issues
- **Questions:** Discussions ou Email
- **PRs:** Follow CONTRIBUTING.md

---

## 📄 Licença

MIT License — Open Source

---

## 👥 Autores

- **Equipe Dev:** Fiscal de Jipa Project
- **Design Pattern:** Seguindo [Akita AI Documentation Patterns](https://github.com/akitaonrails)

---

**Última Atualização:** Março, 2026  
**Status da Doc:** ✅ Completa e Atualizada
