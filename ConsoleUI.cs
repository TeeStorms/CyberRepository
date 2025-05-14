using System;

namespace CyberAwarenessBot
{
    // Handles the user interface interactions for the chatbot
    public static class ConsoleUI // Made the class static as it only contains static methods
    {
        // Displays the introductory message and cybersecurity-themed ASCII art
        public static void DisplayIntro()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green; // Changed to Green to match the ASCII art
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("| 🔒 Welcome to the Cyber Awareness Bot Interface! 🛡️ |"); // More engaging title with emojis
            Console.WriteLine(new string('=', 60));
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow; // Changed to Yellow for the instruction
            Console.WriteLine("\nFor the best experience, please maximize your window!");
            Console.WriteLine("Press any key to continue...");
            Console.ResetColor();
            Console.ReadKey(true);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan; // Consistent with ChatBot responses
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("| 🚀 Get Ready to Boost Your Cybersecurity Knowledge! 🚀 |"); // More exciting welcome
            Console.WriteLine(new string('=', 60));
            Console.ResetColor();

            // Display ASCII art representing cybersecurity awareness
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
          .---.       .---.       .---.       .---.     .----.
         /     \     /     \     /     \     /     \   /      \
        | (_) |     | (_) |     | (_) |     | (_) |  |  .--.  |
        `. .-'       `. .-'       `. .-'       `. .-'   |  |  |  |
          `-'         `-'         `-'         `-'      |  `--'  |
      .---.       .-------.     .-------.     .-------. \      /
     /     \     /         \   /         \   /         \  `----'
    |  O  |     |    .-.    | |    .-.    | |    .-.    |
    `. .-'       |   /   \   | |   /   \   | |   /   \   |
      `-'         |  `-'   '  | |  `-'   '  | |  `-'   '  |
                  `-------'     `-------'     `-------'

        🛡️ Your Digital Guardian is Here! 🛡️
    ");
            Console.ResetColor();
        }

        // Asks the user for their name and ensures a valid response
        public static void AskUserName(out string name)
        {
            Console.ForegroundColor = ConsoleColor.Magenta; // Changed color for emphasis
            Console.WriteLine("Hello there! 👋 What should I call you?"); // More friendly question
            Console.Write("Your name: ");
            name = Console.ReadLine()?.Trim() ?? "Cyber Explorer"; // More engaging default name
            Console.ResetColor();
            Console.WriteLine("\n" + new string('=', 40));
            Console.WriteLine($"Nice to meet you, {name}! Let's get started! 🚀"); // Personalized welcome
            Console.WriteLine(new string('=', 40));
        }

        // Displays chatbot responses in a distinct color for better readability
        public static void Respond(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan; // Consistent with ChatBot
            Console.WriteLine($"\n🤖 Chatbot: {message}\n"); // Added chatbot emoji
            Console.ResetColor();
        }
    }
}