HR Management System

Este é um sistema de gerenciamento de Recursos Humanos que permite o cadastro de colaboradores e empresas,
exibindo essas informações dinamicamente. O backend é desenvolvido em .NET 8 utilizando Dapper para interação com SQL Server,
enquanto o frontend é construído em JavaScript.

Tecnologias Utilizadas

Backend:

.NET 8

Dapper

SQL Server

ASP.NET Web API


Frontend:

JavaScript (Vanilla)

HTML/CSS

Fetch API para comunicação com o backend


Funcionalidades:

Cadastro de Empresa: Permite registrar uma nova empresa no sistema.

Cadastro de Colaborador: Associa um colaborador a uma empresa existente.

Exibição Dinâmica: Os dados cadastrados são carregados e exibidos dinamicamente no frontend.


Instalação e Configuração:

Backend

Clone o repositório:

git clone https://github.com/DavissonJr/hr-management-system.git
cd hr-management-system/backend

Configure a string de conexão com o SQL Server no appsettings.json:

{
    "ConnectionStrings": {
        "DefaultConnection": "Server=SEU_SERVIDOR;Database=HRDatabase;User Id=SEU_USUARIO;Password=SUA_SENHA;"
    }
}

Execute as migrações para criar o banco de dados.

Inicie o backend:

dotnet run

Frontend

Acesse a pasta do frontend:

cd ../frontend

Abra index.html no navegador ou utilize um servidor local como o Live Server.

------ Endpoints da API ------

Colaboradores

GET /api/Colaboradores - Lista todos os colaboradores.

GET /api/Colaboradores/colaborador-id/{id} - Busca um colaborador pelo ID.

GET /api/Colaboradores/buscar-colab-pagina/{pagina}/{quantidade} - Busca colaboradores paginados.

POST /api/Colaboradores/inserir-colaborador - Insere um novo colaborador.

PUT /api/Colaboradores/atualizar-colaborador/{id} - Atualiza os dados de um colaborador.

DELETE /api/Colaboradores/excluir/{id} - Exclui um colaborador.

Empresas

GET /api/Empresas - Lista todas as empresas.

GET /api/Empresas/buscar-id/{id} - Busca uma empresa pelo ID.

GET /api/Empresas/buscar-pagina/{pagina}/{quantidade} - Busca empresas paginadas.

POST /api/Empresas/inserir - Insere uma nova empresa.

PUT /api/Empresas/atualizar - Atualiza os dados de uma empresa.

DELETE /api/Empresas/excluir/{id} - Exclui uma empresa.
