# 📜 C# Cheat Sheet

## 🔹 Methods & Static Methods
```csharp
static void MyMethod()
{
    Console.WriteLine("Hello World");
}
```

## 📌 Lists
```csharp
List<string> tasks = new List<string>();
tasks.Add("New Task");
tasks.RemoveAt(0);
```

## 📂 File Handling
```csharp
File.WriteAllText("tasks.txt", "Task 1\nTask 2");
string content = File.ReadAllText("tasks.txt");
```

## 🔢 Parsing Integers Safely
```csharp
if (int.TryParse(Console.ReadLine(), out int number))
{
    Console.WriteLine($"Valid number: {number}");
}
```

## ⚠️ Exception Handling
```csharp
try
{
    int result = 10 / int.Parse("0");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
```

## ⌨️ Console Key Input Handling
```csharp
ConsoleKeyInfo key = Console.ReadKey();
if (key.Key == ConsoleKey.Enter)
{
    Console.WriteLine("You pressed Enter!");
}
```

