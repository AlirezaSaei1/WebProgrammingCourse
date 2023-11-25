FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebApplicationProject/WebApplicationProject.csproj", "WebApplicationProject/"]
RUN dotnet restore "WebApplicationProject/WebApplicationProject.csproj"
COPY . .
WORKDIR "/src/WebApplicationProject"
RUN dotnet build "WebApplicationProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApplicationProject.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApplicationProject.dll"]
