# Projeto API ASP.NET Core

Este projeto é uma API RESTful desenvolvida em C# utilizando ASP.NET Core. Ele inclui autenticação via JWT e documentação automática via Swagger.

---

## Sumário

- [Tecnologias](#tecnologias)  
- [Funcionalidades](#funcionalidades)  
- [Pré-requisitos](#pré-requisitos)  
- [Como rodar](#como-rodar)  
- [Autenticação JWT](#autenticação-jwt)  
- [Documentação Swagger](#documentação-swagger)  
- [Gitignore recomendado](#gitignore-recomendado)  

---

## Tecnologias

- .NET 7 / .NET 8 (ou versão que você está usando)  
- ASP.NET Core Web API  
- Entity Framework Core (se usar ORM)  
- Swagger / Swashbuckle  
- JWT (Json Web Tokens) para autenticação  

---

## Funcionalidades

- API RESTful com endpoints para [descrição das funcionalidades da API]  
- Autenticação via JWT  
- Validação e tratamento de erros  
- Documentação interativa com Swagger UI  

---

## Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) (versão compatível com o projeto)  
- Visual Studio ou VS Code  
- Banco de dados configurado (se aplicável)  

---

## Documentação Swagger

Este projeto possui documentação interativa da API com Swagger UI, que permite:

- Visualizar todos os endpoints disponíveis  
- Ver detalhes dos parâmetros, tipos de dados e respostas  
- Testar as requisições diretamente no navegador  

Para acessar a documentação, acesse no navegador:
http://localhost:5099/swagger/index.html
O Swagger é configurado usando o pacote `Swashbuckle.AspNetCore` e está automaticamente integrado na aplicação.

---

## Gitignore recomendado

Para evitar subir arquivos desnecessários ou que podem causar conflitos, inclua no seu `.gitignore`:
## Dicas finais

- Sempre mantenha seu `appsettings.json` com configurações genéricas e use arquivos de ambiente (`appsettings.Development.json`, etc.) para configurações locais/sensíveis.  
- Nunca suba senhas ou chaves secretas para o repositório público.  
- Use variáveis de ambiente para configurar o segredo do JWT em produção.  
- Teste a API com o Swagger antes de consumir pelo frontend.  
- Leia a documentação do ASP.NET Core para aprofundar em segurança, middleware e boas práticas.  

---

## Contato

Se precisar de ajuda ou quiser contribuir, abra issues ou pull requests no repositório.

---

**Boa sorte no projeto! 🚀**
