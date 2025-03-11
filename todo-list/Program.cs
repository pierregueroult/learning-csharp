namespace TodoList
{
    static class Program
    {
        static List<Task> tasks = [];
        
        static public void Main()
        {
            bool running = true;

            LoadTasks();

            while (running)
            {
                DisplayMenu(tasks);

                string? choice = Console.ReadLine()?.ToLower();

                if (choice == null)
                {
                    Console.Write("Invalid command");
                }
                else
                {
                    running = ProcessCommand(choice, tasks);
                    SaveTasks(tasks);
                }
            }
        }

        static void DisplayMenu(List<Task> tasks)
        {
            Console.Clear();
            Console.WriteLine("/------- Welcome to the Todo List -------\\");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }

            Console.WriteLine("\nCommands:");
            Console.WriteLine("     add - Add a new task");
            Console.WriteLine("     toggle - Toggle a task as complete");
            Console.WriteLine("     edit - Edit a task");
            Console.WriteLine("     remove - Remove a task");
            Console.WriteLine("     quit - Exit the program");

            Console.Write("\nEnter a command: ");
        }

        static bool ProcessCommand(string choice, List<Task> tasks)
        {
            switch (choice)
            {
                case "add":
                    AddTask(tasks);
                    break;
                case "toggle":
                    ToggleTask(tasks);
                    break;
                case "edit":
                    EditTask(tasks);
                    break;
                case "remove":
                    RemoveTask(tasks);
                    break;
                case "quit":
                    Console.Write("You chose to quit the program");
                    return false;
                default:
                    Console.Write("Invalid command");
                    break;
            }
            return true;
        }

        static void AddTask(List<Task> tasks)
        {
            Console.Write("Let's add a task. What do you need to do? ");
            string? description = Console.ReadLine();
            if (description == null)
            {
                Console.Write("Invalid task description");
                Console.ReadKey();
            }
            else
            {
                tasks.Add(new Task(description));
            }
        }

        static void ToggleTask(List<Task> tasks)
        {
            Console.Write("Which task would you like to toggle? ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
            {
                tasks[index - 1].IsComplete = !tasks[index - 1].IsComplete;
            }
            else
            {
                Console.Write("Invalid task number");
                Console.ReadKey();
            }
        }

        static void RemoveTask(List<Task> tasks)
        {
            Console.Write("Which task would you like to remove? ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
            {
                tasks.RemoveAt(index - 1);
            }
            else
            {
                Console.Write("Invalid task number");
                Console.ReadKey();
            }
        }

        static void EditTask(List<Task> tasks)
        {
            Console.Write("Which task would you like to edit? ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
            {
                Console.Write("Enter the new description: ");
                string? description = Console.ReadLine();
                if (description == null)
                {
                    Console.Write("Invalid task description");
                    Console.ReadKey();
                }
                else
                {
                    tasks[index - 1].Description = description;
                }
            }
            else
            {
                Console.Write("Invalid task number");
                Console.ReadKey();
            }
        }

        static void SaveTasks(List<Task> tasks)
        {
            File.WriteAllLines("tasks.txt", tasks.Select(t => $"{t.IsComplete}|{t.Description}"));
        }

        static void LoadTasks() {
            if (File.Exists("tasks.txt")) {
                tasks = File.ReadAllLines("tasks.txt")
                    .Select(line => line.Split('|'))
                    .Select(parts => new Task(parts[1]) { IsComplete = bool.Parse(parts[0]) })
                    .ToList();
            }
        }
    }

    class Task(string description)
    {
        public string Description { get; set; } = description;
        public bool IsComplete { get; set; } = false;

        public override string ToString()
        {
            return $"{(IsComplete ? "[x]" : "[ ]")} {Description}";
        }
    }
}