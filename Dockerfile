FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["TestAsp/TestAsp.csproj", "TestAsp/"]
RUN dotnet restore "TestAsp/TestAsp.csproj"
COPY . .
WORKDIR "/src/TestAsp"
RUN dotnet publish "TestAsp.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "TestAsp.dll"]