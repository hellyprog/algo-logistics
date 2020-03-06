FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ./*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ${file%.*}/ && mv $file ${file%.*}/; done
RUN dotnet restore "AlgoLogistics/AlgoLogistics.csproj"
COPY . .
WORKDIR "/src/AlgoLogistics"
RUN dotnet build "AlgoLogistics.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "AlgoLogistics.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AlgoLogistics.dll"]
