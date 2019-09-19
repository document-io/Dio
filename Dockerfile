FROM node:12 as frontend
COPY ./src/DocumentIO.Frontend /documentio
WORKDIR /documentio
RUN npm i
RUN npm run build

FROM mcr.microsoft.com/dotnet/core/sdk:3.0.100-preview9-alpine3.9 AS backend
COPY . /documentio
WORKDIR /documentio
RUN dotnet test
RUN dotnet publish -c Release -o build src/DocumentIO.Web

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0.0-preview9-alpine3.9 AS documentio
WORKDIR /documentio
COPY --from=frontend /documentio/build ./frontend
COPY --from=backend /documentio/build .
ENTRYPOINT ["dotnet", "DocumentIO.Web.dll"]