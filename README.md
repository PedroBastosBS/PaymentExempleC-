# Projeto API ASP.NET Core

Este projeto é uma API RESTful desenvolvida em C# com ASP.NET Core. Ele conta com documentação automática via Swagger para facilitar o uso e teste dos endpoints.

⚠️ **Atenção:** O Dockerfile ainda **não está funcional**. Execute o projeto **manualmente** conforme instruções abaixo.

---

## Sumário

- [Tecnologias](#tecnologias)  
- [Funcionalidades](#funcionalidades)  
- [Pré-requisitos](#pré-requisitos)  
- [Como rodar manualmente](#como-rodar-manualmente)  
- [Documentação Swagger](#documentação-swagger)  
- [Gitignore recomendado](#gitignore-recomendado)  

---

## Tecnologias

- .NET 7 / .NET 8  
- ASP.NET Core Web API  
- Entity Framework Core (opcional)  
- Swagger / Swashbuckle  

---

## Funcionalidades

- Endpoints RESTful  
- Validação e tratamento de erros  
- Documentação interativa via Swagger UI  

---

## Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download)  
- Visual Studio ou VS Code  
- Banco de dados configurado (se aplicável)  

---

## Como rodar manualmente

```bash
# Clone o repositório
git clone https://github.com/PedroBastosBS/api-payment
cd api-payment

# Restaure dependências e execute
dotnet restore
dotnet run
```
Após rodar o comando acima, você verá uma saída semelhante no terminal:

mathematica
Copiar
Editar

Now listening on: http://localhost:5099
Application started. Press Ctrl+C to shut down.

---

## Documentação da API 

http://localhost:5099/swagger/index.html

---

### Configurando o banco de dados (opcional)

Se sua API utiliza um banco de dados com Entity Framework Core, siga os passos abaixo:

#### 1. Configure a string de conexão

No arquivo `appsettings.Development.json` (ou `appsettings.json`), ajuste a string de conexão com o seu banco de dados:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=MeuBanco;User Id=meu-usuario;Password=minha-senha;"
}