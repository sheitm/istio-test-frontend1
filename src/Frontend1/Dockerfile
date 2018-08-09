FROM microsoft/dotnet:2.1-sdk AS build
LABEL maintainer="hafslundnett@hafslundnett.no"
WORKDIR /app
COPY . .
RUN dotnet restore ./Frontend1.csproj \
    && dotnet publish ./Frontend1.csproj -o ./out -c Release

FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "Frontend1.dll"]