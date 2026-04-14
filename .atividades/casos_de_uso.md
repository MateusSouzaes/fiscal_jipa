%%{init: {'theme': 'base', 'themeVariables': { 'primaryColor':'#1f77b4', 'primaryBorderColor':'#1f77b4', 'lineColor':'#ff6b6b', 'secondBkgColor':'#4ecdc4', 'tertiaryColor':'#f1e15b'}, 'flowchart': {'curve': 'linear'}}}%%

graph TB
    subgraph "🌐 ATORES EXTERNOS"
        UC["👤 Usuário Civil<br/>Visualizador"]
        SG["👨‍💼 Servidor Gestor<br/>Gerenciador"]
        AU["🔍 Auditor<br/>Fiscalizador"]
        AD["⚙️ Admin<br/>Gerente Sistema"]
        API["🔗 API PNCP<br/>Dados Públicos"]
    end

    subgraph "🎯 CASOS DE USO - CONTRATOS"
        CU1["📋 Ver Contratos"]
        CU2["🔍 Buscar Contratos"]
        CU3["📊 Ver Detalhes"]
        CU4["➕ Criar Contrato"]
        CU5["✏️ Editar Contrato"]
        CU6["🗑️ Deletar Contrato"]
        CU7["📥 Categorizar"]
        CU8["💰 Calcular Saldo"]
    end

    subgraph "💬 CASOS DE USO - COLABORAÇÃO"
        CU9["💭 Comentar"]
        CU10["❤️ Curtir"]
        CU11["👁️ Seguir Contrato"]
        CU12["⏰ Configurar Alertas"]
        CU13["🔔 Receber Notificações"]
    end

    subgraph "📈 CASOS DE USO - DASHBOARDS"
        CU14["📊 Dashboard Financeiro"]
        CU15["📉 Gráfico Gastos/Mês"]
        CU16["🥧 Gráfico Categorias"]
        CU17["🏆 Top Fornecedores"]
        CU18["⏱️ Timeline Vigência"]
    end

    subgraph "🔐 CASOS DE USO - ADMIN/AUDITORIA"
        CU19["👥 Gerenciar Usuários"]
        CU20["🔑 Gerenciar Roles"]
        CU21["🛡️ Gerenciar Permissões"]
        CU22["🔄 Sincronizar PNCP"]
        CU23["📋 Ver Logs Auditoria"]
        CU24["📄 Gerar Relatórios"]
    end

    subgraph "⚡ CASOS DE USO - SISTEMA"
        CU25["🔄 Atualizar BD"]
        CU26["📌 Validar Dados"]
        CU27["🚨 Disparar Alerta"]
    end

    %% Conexões Usuário Civil
    UC -->|acesso| CU1
    UC -->|usa| CU2
    UC -->|clica| CU3
    UC -->|realiza| CU9
    UC -->|realiza| CU10
    UC -->|realiza| CU11
    UC -->|configura| CU12
    UC -->|recebe| CU13
    UC -->|acessa| CU14
    UC -->|visualiza| CU15
    UC -->|visualiza| CU16
    UC -->|visualiza| CU17

    %% Conexões Gestor
    SG -->|acesso| CU1
    SG -->|usa| CU2
    SG -->|clica| CU3
    SG -->|realiza| CU4
    SG -->|realiza| CU5
    SG -->|realiza| CU6
    SG -->|realiza| CU9
    SG -->|acessa| CU14
    SG -->|configura| CU12
    SG -->|deleta| CU10

    %% Conexões Auditor
    AU -->|acesso| CU1
    AU -->|usa| CU2
    AU -->|clica| CU3
    AU -->|acessa| CU14
    AU -->|acessa| CU23
    AU -->|realiza| CU24

    %% Conexões Admin
    AD -->|gerencia| CU19
    AD -->|configura| CU20
    AD -->|configura| CU21
    AD -->|executa| CU22
    AD -->|acessa| CU23
    AD -->|acessa| CU14

    %% Conexões Sistema PNCP
    API -->|fornece| CU25
    CU25 -->|inclui| CU7
    CU25 -->|inclui| CU8
    CU26 -->|valida| CU25
    CU27 -->|dispara| CU13

    %% Relações entre CUs
    CU2 -->|localiza| CU3
    CU4 -->|inclui| CU7
    CU4 -->|inclui| CU8
    CU5 -->|inclui| CU7
    CU5 -->|inclui| CU8
    CU12 -->|monitora| CU27
    CU22 -->|dispara| CU25
    
    style UC fill:#e8f4f8,stroke:#1f77b4,stroke-width:3px,color:#000
    style SG fill:#fff4e1,stroke:#ff9800,stroke-width:3px,color:#000
    style AU fill:#f0e8ff,stroke:#9c27b0,stroke-width:3px,color:#000
    style AD fill:#e8f5e9,stroke:#4caf50,stroke-width:3px,color:#000
    style API fill:#ffebee,stroke:#f44336,stroke-width:3px,color:#000

    style CU1 fill:#b3e5fc,stroke:#0288d1,stroke-width:2px
    style CU2 fill:#b3e5fc,stroke:#0288d1,stroke-width:2px
    style CU3 fill:#b3e5fc,stroke:#0288d1,stroke-width:2px
    style CU4 fill:#ffe0b2,stroke:#f57c00,stroke-width:2px
    style CU5 fill:#ffe0b2,stroke:#f57c00,stroke-width:2px
    style CU6 fill:#ffe0b2,stroke:#f57c00,stroke-width:2px
    style CU7 fill:#fff9c4,stroke:#fbc02d,stroke-width:2px
    style CU8 fill:#fff9c4,stroke:#fbc02d,stroke-width:2px

    style CU9 fill:#f8bbd0,stroke:#c2185b,stroke-width:2px
    style CU10 fill:#f8bbd0,stroke:#c2185b,stroke-width:2px
    style CU11 fill:#f8bbd0,stroke:#c2185b,stroke-width:2px
    style CU12 fill:#f8bbd0,stroke:#c2185b,stroke-width:2px
    style CU13 fill:#f8bbd0,stroke:#c2185b,stroke-width:2px

    style CU14 fill:#c8e6c9,stroke:#388e3c,stroke-width:2px
    style CU15 fill:#c8e6c9,stroke:#388e3c,stroke-width:2px
    style CU16 fill:#c8e6c9,stroke:#388e3c,stroke-width:2px
    style CU17 fill:#c8e6c9,stroke:#388e3c,stroke-width:2px
    style CU18 fill:#c8e6c9,stroke:#388e3c,stroke-width:2px

    style CU19 fill:#d1c4e9,stroke:#512da8,stroke-width:2px
    style CU20 fill:#d1c4e9,stroke:#512da8,stroke-width:2px
    style CU21 fill:#d1c4e9,stroke:#512da8,stroke-width:2px
    style CU22 fill:#d1c4e9,stroke:#512da8,stroke-width:2px
    style CU23 fill:#d1c4e9,stroke:#512da8,stroke-width:2px
    style CU24 fill:#d1c4e9,stroke:#512da8,stroke-width:2px

    style CU25 fill:#ffccbc,stroke:#d84315,stroke-width:2px
    style CU26 fill:#ffccbc,stroke:#d84315,stroke-width:2px
    style CU27 fill:#ffccbc,stroke:#d84315,stroke-width:2px
