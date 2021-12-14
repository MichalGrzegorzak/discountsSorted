:: https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-sln
:: dotnet new --list

dotnet new sln

dotnet new classlib --output models
dotnet sln add models

dotnet new xunit --output unitTests
dotnet sln add unitTests