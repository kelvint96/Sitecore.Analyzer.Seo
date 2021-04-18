#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Web/WebMVC/WebMVC/WebMVC.csproj", "Web/WebMVC/WebMVC/"]
COPY ["Web/WebMVC/Application/WebMVC.Application.csproj", "Web/WebMVC/Application/"]
COPY ["Web/WebMVC/Domain/WebMVC.Domain.csproj", "Web/WebMVC/Domain/"]
RUN dotnet restore "Web/WebMVC/WebMVC/WebMVC.csproj"
COPY . .
WORKDIR "/src/Web/WebMVC/WebMVC"
RUN dotnet build "WebMVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebMVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebMVC.dll"]
