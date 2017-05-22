dotnet restore ./Deckr/Deckr.csproj
dotnet restore ./Deckr.Tests/Deckr.Tests.csproj
dotnet restore ./Deckr.Console/Deckr.Console.csproj
dotnet restore ./Deckr.Console.Tests/Deckr.Console.Tests.csproj
dotnet restore ./Deckr.Web/Deckr.Web.csproj
dotnet restore ./Deckr.Web.Tests/Deckr.Web.Tests.csproj


dotnet build ./Deckr/Deckr.csproj
dotnet build ./Deckr.Tests/Deckr.Tests.csproj
dotnet build ./Deckr.Console/Deckr.Console.csproj
dotnet build ./Deckr.Console.Tests/Deckr.Console.Tests.csproj
dotnet build ./Deckr.Web/Deckr.Web.csproj
dotnet build ./Deckr.Web.Tests/Deckr.Web.Tests.csproj
