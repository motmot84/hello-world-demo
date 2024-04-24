FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /
COPY ["hello-world-demo/hello-world-demo.csproj", "hello-world-demo/"]
RUN dotnet restore "hello-world-demo/hello-world-demo.csproj"
COPY ./ .
WORKDIR /hello-world-demo
RUN dotnet build "hello-world-demo.csproj" -c Release -o /app

FROM build as publish
RUN dotnet publish "hello-world-demo.csproj" -c Release -o /app

FROM runtime AS final
WORKDIR /app
COPY --from=publish /app .

EXPOSE 8080

ENTRYPOINT [ "dotnet", "hello-world-demo.dll" ]