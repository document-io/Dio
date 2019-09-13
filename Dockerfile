FROM node:12 as frontend
COPY ./src/DocumentIO.Frontend /documentio/frontend
WORKDIR /documentio/frontend
RUN npm run build

FROM mcr.microsoft.com/dotnet/core/sdk:3.0.100-preview9-alpine3.9 AS backend
COPY . /documentio/backend
WORKDIR /documentio/backend/src/DocumentIO.Web
RUN dotnet publish -c Release -o artifacts

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0.0-preview9-alpine3.9 AS documentio
WORKDIR /documentio/web
COPY --from=frontend /documentio/frontend/build ./frontend
COPY --from=backend /documentio/backend/src/DocumentIO.Web/artifacts ./
ENTRYPOINT ["dotnet", "DocumentIO.Web.dll"]