cd /d %~dp0

dotnet clean -c Release
dotnet publish -c Release -r win-x64 -p:PublishAot=true

