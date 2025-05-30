# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Restaura dependências
RUN dotnet restore

# Copia o restante do código
COPY . .

# Publica a aplicação em modo Release
WORKDIR /app/PaymentService.Api
RUN dotnet publish -c Release -o out

# Etapa final - imagem de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/PaymentService.Api/out .

EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80

ENTRYPOINT ["dotnet", "PaymentService.Api.dll"]
