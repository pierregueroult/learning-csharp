
# 📝 C# Cheat Sheet

## 🏗 String Manipulation
```csharp
string text = "Hello, World!";
string lower = text.ToLower(); // Convert to lowercase
string[] words = text.Split(' '); // Split string into words
```

## 🔄 Loops
```csharp
foreach (string word in words)
{
    Console.WriteLine(word);
}
```

## 📚 Lists & Dictionaries
```csharp
List<string> wordsList = new List<string>();
wordsList.Add("Example");

Dictionary<string, int> wordCount = new Dictionary<string, int>();
if (wordCount.ContainsKey("example"))
    wordCount["example"]++;
else
    wordCount["example"] = 1;
```

## 🔎 Sorting with LINQ
(LINQ (Language Integrated Query) is a powerful feature in C# that allows you to query and manipulate data in a more readable and concise way. It can be used with various data sources, such as collections, databases, XML, and more. LINQ provides a set of query operators that can be used to perform filtering, projection, aggregation, sorting, and other operations on data.)
```csharp
var sortedWords = wordCount.OrderByDescending(kvp => kvp.Value).Take(5);
```

In the example above, `OrderByDescending` is a LINQ method that sorts the dictionary by its values in descending order, and `Take(5)` selects the top 5 elements from the sorted result.
```csharp
var sortedWords = wordCount.OrderByDescending(kvp => kvp.Value).Take(5);
```

## 📝 File Handling
```csharp
File.WriteAllText("analysis.txt", "Sample text");
string content = File.ReadAllText("analysis.txt");
```

✅ **This project reinforced my understanding of text processing in C# and introduced new ways to handle data efficiently!** 🚀

