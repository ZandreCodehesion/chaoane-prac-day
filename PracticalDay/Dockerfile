FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["chaoane-prac-day/PracticalDay/PracticalDay.csproj", "PracticalDay/"]
RUN dotnet restore "PracticalDay/PracticalDay.csproj"
COPY . .
WORKDIR "/src/PracticalDay"
RUN dotnet build "PracticalDay.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PracticalDay.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PracticalDay.dll"]
