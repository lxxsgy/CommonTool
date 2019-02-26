FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["aspnetCoredemo1/aspnetCoredemo1.csproj", "aspnetCoredemo1/"]
RUN dotnet restore "aspnetCoredemo1/aspnetCoredemo1.csproj"
COPY . .
WORKDIR "/src/aspnetCoredemo1"
RUN dotnet build "aspnetCoredemo1.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "aspnetCoredemo1.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "aspnetCoredemo1.dll"]