namespace TextAnalyzer
{
    static class Program
    {

        static Dictionary<string, int> wordFrequency = new();

        static void Main()
        {
            Console.WriteLine("Enter a text for the program to analyze:");
            string? text = Console.ReadLine();

            if (text == null || string.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("The text is empty. Exiting...");
                return;
            }


            Console.WriteLine("Starting count analyzing the text...");
            int wordCount = CountWords(text);
            Console.WriteLine($"Word count: {wordCount}");
            int sentenceCount = CountSentences(text);
            Console.WriteLine($"Sentence count: {sentenceCount}");
            int paragraphCount = CountParagraphs(text);
            Console.WriteLine($"Paragraph count: {paragraphCount}");
            int characterCount = CountCharacters(text);
            Console.WriteLine($"Character count: {characterCount}");
            Console.WriteLine("Count analysis complete. \n\n");

            Console.WriteLine("Starting word frequency analysis...");
            WordsFrequency(text);
            Console.WriteLine("Here are the top 10 most frequent words:");
            foreach (KeyValuePair<string, int> word in wordFrequency.Take(10))
            {
                Console.WriteLine($"{word.Key}: {word.Value}");
            }
            Console.WriteLine("Word frequency analysis complete.");

            Console.WriteLine("Looking for longest and shortest words...");
            LongestShortestWords(text);
            Console.WriteLine("Longest and shortest words analysis complete.");
        }

        static int CountWords(string text)
        {
            string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        static int CountSentences(string text)
        {
            string[] sentences = text.Split('.', StringSplitOptions.RemoveEmptyEntries);
            return sentences.Length;
        }

        static int CountParagraphs(string text)
        {
            string[] paragraphs = text.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            return paragraphs.Length;
        }

        static int CountCharacters(string text)
        {
            return text.Length;
        }

        static void WordsFrequency(string text)
        {
            string[] words = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                string cleaned = word.Trim(',', '.', '!', '?', ';', ':', '(', ')', ' ');

                if (string.IsNullOrEmpty(cleaned))
                {
                    continue;
                }

                if (wordFrequency.TryGetValue(cleaned, out int value))
                {
                    wordFrequency[cleaned] = ++value;
                }
                else
                {
                    wordFrequency.Add(cleaned, 1);
                }
            }

            wordFrequency = wordFrequency.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }

        static void LongestShortestWords(string text)
        {
            string[] words = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string longestWord = words.OrderByDescending(x => x.Length).First();
            string shortestWord = words.OrderBy(x => x.Length).First();

            Console.WriteLine($"Longest word: {longestWord}");
            Console.WriteLine($"Shortest word: {shortestWord}");
        }
    }
}