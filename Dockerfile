# Imagen base para runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Imagen base para compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["orderManage.Api/orderManage.Api.csproj", "orderManage.Api/"]
COPY ["orderManage.Application/orderManage.Application.csproj", "orderManage.Application/"]
COPY ["orderManage.Domain/orderManage.Domain.csproj", "orderManage.Domain/"]
COPY ["orderManage.Infrastructure/orderManage.Infrastructure.csproj", "orderManage.Infrastructure/"]
RUN dotnet restore "orderManage.Domain/orderManage.Domain.csproj"
RUN dotnet restore "orderManage.Application/orderManage.Application.csproj"
RUN dotnet restore "orderManage.Infrastructure/orderManage.Infrastructure.csproj"
RUN dotnet restore "orderManage.Api/orderManage.Api.csproj"


COPY . .
WORKDIR "/src/orderManage.Api"
RUN dotnet publish "orderManage.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Imagen final
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "orderManage.Api.dll"]


ENV ConnectionStrings__DefaultConnection=""