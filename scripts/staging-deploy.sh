#!/bin/bash
set -e

# navigate to repo root and fetch lates change
cd  $(git rev-parse --show-toplevel)

git checkout staging
git pull origin staging

# install dependencies
dotnet restore Hng.Csharp.Web.sln

# build app
dotnet build -c Release -o ./src/Hng.Web/bin/Staging/build

# publish app
dotnet build -c Release -o ./src/Hng.Web/bin/Staging/publish

# restart the systemd service
sudo systemctl restart hng-web-staging

