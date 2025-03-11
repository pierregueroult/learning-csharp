using TextCopy;

namespace PasswordGenerator
{
    static class Program 
    {
        static void Main() 
        {
            Console.WriteLine("Bienvenue dans le générateur de mot de passe !");

            Thread.Sleep(2000);

            Console.WriteLine("Veuillez entrer la longueur du mot de passe :");
            int length;

            while (!int.TryParse(Console.ReadLine(), out length) || length <= 4)
            {
                Console.WriteLine("Veuillez entrer un nombre valide (supérieur à 4).");
            }

            bool includeUpperCase = AskOption("Inclure des majuscules ? (O/N)");
            bool includeNumbers = AskOption("Inclure des chiffres ? (O/N)");
            bool includeSpecialCharacters = AskOption("Inclure des caractères spéciaux ? (O/N)");

            Console.WriteLine("Votre mot de passe suivra les critères suivants :");
            Console.WriteLine($"Longueur : {length}");
            Console.WriteLine($"Majuscules : {(includeUpperCase ? "Oui" : "Non")}");
            Console.WriteLine($"Chiffres : {(includeNumbers ? "Oui" : "Non")}");
            Console.WriteLine($"Caractères spéciaux : {(includeSpecialCharacters ? "Oui" : "Non")}");

            if (!AskOption("Confirmer ? (O/N)"))
            {
                Console.WriteLine("Opération annulée.");
                return;
            }

            string password = generatePassword(length, includeUpperCase, includeNumbers, includeSpecialCharacters);

            Console.WriteLine($"Votre mot de passe est : {password}");

            if (AskOption("Copier le mot de passe dans le presse-papiers ? (O/N)"))
            {
                ClipboardService.SetText(password);
                Console.WriteLine("Mot de passe copié dans le presse-papiers.");
            }

            Console.WriteLine("Merci d'avoir utilisé le générateur de mot de passe !");
            Console.WriteLine("Appuyez sur une touche pour quitter...");
            Console.ReadKey();
        }

        static bool AskOption(string message) {
            Console.WriteLine(message);
            string? input = Console.ReadLine()?.ToLower();

            while(input != "o" && input != "n") {
                Console.WriteLine("Veuillez entrer une option valide (O/N).");
                input = Console.ReadLine()?.ToLower();
            }

            return input == "o";
        }

        static string generatePassword(int length, bool uppercases, bool numbers, bool specialCharacters) {
            const string lowercase = "abcdefghijklmnopqrstuvwxyz";
            const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string digits = "0123456789";
            const string special = "!@#$%^&*()-_+-=[]{};':,.<>?";

            string characters = lowercase;
            if (uppercases) characters += uppercase;
            if (numbers) characters += digits;
            if (specialCharacters) characters += special;

            Random random = new();

            char[] password = new char[length];

            for (int i = 0; i < length; i++) {
                password[i] = characters[random.Next(characters.Length)];
            }

            return new string(password);
        }
    }
}