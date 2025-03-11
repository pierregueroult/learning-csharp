# ✅ What This Project Taught Me in C#

## 🏗 Creating and Running a .NET Project
- dotnet new console -o MyProject → Create a new console project
- dotnet run → Run the project

## 🖥 Console Interaction
- Console.WriteLine("Text") → Print a message
- Console.ReadLine() → Read user input
- Console.ReadKey(); → Wait for a key press before exiting

## 🔢 Validating User Input
- int.TryParse(Console.ReadLine(), out int number) → Check if input is a number without throwing an exception
- while loop to ensure valid input

## 🎲 Generating Random Numbers in C#
- Random rand = new Random(); → Initialize a random number generator
- rand.Next(min, max) → Generate a number between min and max - 1

## 📋 Advanced String Manipulation (C# Specific)
- $"Text {variable}" → String interpolation (better than +)
- string.Join("", array) → Join an array of characters into a string
- text.Contains("abc") → Check if a substring exists
- text.IndexOf('a') → Find the position of a character

## 📌 Clipboard Management (via NuGet)
- Install a NuGet package:
```shell
dotnet add package TextCopy
```
- Copy text with one command:
```shell
ClipboardService.SetText("Text to copy");
```

## 🔄 Functions and Modularity in C#
- Define a function 
```c#
static int Add(int a, int b)
{
    return a + b;
}
```
- Call a function:
```c#
int sum = Add(5, 3);
```

## Compiling and Generating an Executable in C#
- Compiling and Generating an Executable in C#
```shell
dotnet publish -c Release -r osx-arm64 --self-contained true
```
- Single-file executable (without DLLs):
```shell
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
```