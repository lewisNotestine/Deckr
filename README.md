# Deckr
Fully featured card shuffling and sorting suite written for .NET Core using .NET Standard v1.6. This is just a little exercise, i used this to test out xUnit, VS 2017 and VS Mac,
as well as to take the opportunity to dive a little deeper into ASP.NET Core MVC.  

This repo contains the Deckr core project (just called "Deckr"), as well as a command-line app "Deckr.Console" and a basic Web UI "Deckr.Web". 

## Prerequisites:
This project requires .NET core SDK (was developed with SDK v1.0.3, and .NET Core Framework v.1.1.0) to run. To run the scripts here, .NET CLI will also be required.

## Building
To build Deckr you can do any of the following: 
* From the project root directory just run the `deckr-build.sh` on a mac or linux envt, or the `deckr-build.bat` file on Windows.
* Open the .sln file in Visual Studio (I tried it in both VS2017 and VS Mac) and build in the IDE. 
* Just run `dotnet restore` and `dotnet build` respectively for each of the projects as needed. 

## Running
To run the console app:

from root dir:
```
cd Deckr.Console
dotnet run
```

Likewise to run the web app:
```
cd Deckr.Web
dotnet run
```

## Testing
This project uses Xunit unit tests. I wanted to see what they were like, it turns out that, at least superficially, they're a lot like NUnit. I chose XUnit over NUnit because it's better supported for .NET Core projects
(esp in a non-Windows envt). There are script files to run the tests from cmd line, `deckr-runtests.sh` for Mac and Linux, `deckr-runtests.bat` for Windows.

## Other Notes
The web app uses two JavaScript libraries - Jquery and Knockout.  These are included under version control here just to make sure they work. Other dependencies should be able to be met with Nuget just by doing regular ol' `dotnet restore` or by building in VS.

