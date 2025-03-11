# 📜 C# Console App Cheat Sheet

## Read User Input (with Numeric Validation)
```c#
Console.Write("Enter a number: ");
if (int.TryParse(Console.ReadLine(), out int number))
{
    Console.WriteLine($"You entered {number}");
}
else
{
    Console.WriteLine("Invalid input.");
}
```

## Generate a Random Password
```c#
Random rand = new Random();
const string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*";
string password = new string(Enumerable.Range(0, 12)
    .Select(_ => characters[rand.Next(characters.Length)]).ToArray());

Console.WriteLine($"Generated password: {password}");
```

## Copy Text to Clipboard
```c#
using TextCopy;
ClipboardService.SetText("Password copied!");
```

## Compile an executable
```bash
dotnet publish -c Release -r win-x64 --self-contained true
```