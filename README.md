# FISCAL JIPA: API REST para Transparência Ativa em Contratos Públicos via PNCP

**IFRO** — Campus Ji-Paraná | **Autor**: Mateus Souza e Silva | **Prof**: João Eujácio Teixeira Júnior | **2026**

---

## 📋 Descrição

API REST que integra dados do PNCP, oferecendo buscas em linguagem natural, dashboards financeiros, alertas automatizados e RBAC para contratos públicos.

## 🎯 Funcionalidades

- ✅ Busca de contratos sem autenticação
- ✅ Sincronização diária com PNCP
- ✅ Dashboards com KPIs
- ✅ Motor de categorização automática
- ✅ RBAC (5 níveis)
- ✅ Alertas inteligentes
- ✅ Auditoria completa

## 🛠️ Tech Stack

| Componente | Tecnologia |
|-----------|-----------|
| Backend | C# .NET 8 |
| Frontend | EJS + Node.js |
| Database | MySQL 8.0+ |
| Docs | Swagger/OpenAPI |

## 🚀 Setup Rápido

```bash
# Clonar
git clone https://github.com/MateusSouzaes/fiscal_jipa.git
cd fiscal_jipa

# Ambiente
cp .env.example .env

# Database
mysql -u root -p < database/01-schema.sql

# Backend
cd backend && dotnet run  # localhost:5000

# Frontend (novo terminal)
cd frontend && npm install && npm start  # localhost:3000
```

## 📡 Endpoints

```
GET  /api/v1/contratos?pagina=1&tamanho=20
GET  /api/v1/contratos/{id}
GET  /api/v1/contratos/{id}/saldo
GET  /api/v1/dashboard/resumo
GET  /api/health
```

Swagger: http://localhost:5000/swagger

## 📊 Requisitos Funcionais

| RF | Descrição |
|----|-----------|
| RF-01 | Buscar contratos sem autenticação |
| RF-02 | Sincronizar com PNCP diariamente |
| RF-03 | Dashboard com KPIs |
| RF-04 | RBAC (5 níveis) |
| RF-05 | Alertas automatizados |
| RF-06 | Auditoria imutável |

## 📁 Estrutura

```
fiscal-jipa/
├── backend/             (API C# .NET)
├── frontend/            (EJS + Node.js)
├── database/            (Scripts SQL)
├── .atividades/         (Documentação)
└── README.md
```

## 🧪 Testes

```bash
# Backend
dotnet test

# Frontend
npm run test:e2e
```

## 📚 Documentação

- [Backend README](./backend/README.md)
- [Especificação Técnica](.atividades/ESPECIFICACAO_API_FISCAL_SIMPLIFICADA.md)
- [API Swagger](http://localhost:5000/swagger)

## 📞 Contato

**Disciplina**: Programação Back-End Avançada  
**Período**: 6º Período - 2026  
**Status**: Desenvolvimento

---

*Última atualização: Abril de 2026*
