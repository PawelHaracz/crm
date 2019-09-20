FROM mcr.microsoft.com/dotnet/core/sdk:3.0.100-rc1-bionic AS builder

ARG feed='--source "https://api.nuget.org/v3/index.json"'

WORKDIR /src
COPY ["src/BuildingBlocks/CRM.DataContract/*.csproj", "src/BuildingBlocks/CRM.DataContract/"]
COPY ["src/BuildingBlocks/CRM.Shared/*.csproj", "src/BuildingBlocks/CRM.Shared/"]
COPY ["src/Gateways/CRM.Graph.Gateway/*.csproj", "src/Gateways/CRM.Graph.Gateway/"]
RUN dotnet restore src/Gateways/CRM.Graph.Gateway/ /property:Configuration=Release ${feed} -nowarn:msb3202,nu1503

COPY ["src/proto/.", "src/proto/"]

COPY ["src/BuildingBlocks/CRM.DataContract/.", "src/BuildingBlocks/CRM.DataContract/"]
COPY ["src/BuildingBlocks/CRM.Shared/.", "src/BuildingBlocks/CRM.Shared/"]
COPY ["src/Gateways/CRM.Graph.Gateway/.", "src/Gateways/CRM.Graph.Gateway/"]
RUN dotnet publish src/Gateways/CRM.Graph.Gateway/ -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0.0-rc1-bionic
WORKDIR /app

ENV ASPNETCORE_URLS http://*:80
ENV ASPNETCORE_ENVIRONMENT docker

COPY --from=builder /app .

EXPOSE 80
ENTRYPOINT [ "dotnet",  "CRM.Graph.Gateway.dll"]