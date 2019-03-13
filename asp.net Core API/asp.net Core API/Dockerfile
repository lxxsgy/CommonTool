FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["asp.net Core API/asp.net Core API.csproj", "asp.net Core API/"]
RUN dotnet restore "asp.net Core API/asp.net Core API.csproj"
COPY . .
WORKDIR "/src/asp.net Core API"
RUN dotnet build "asp.net Core API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "asp.net Core API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "asp.net Core API.dll"]