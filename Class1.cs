using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberAwarenessBot
{
    // Class responsible for chatbot interaction and user communication
    class CyberSecurityChatBot
    {
        // Private field to store the user's name
        private string UserName;

        /// <summary>
        /// Constructor to initialize the chatbot with a username.
        /// </summary>
        /// <param name="userName">The name of the user interacting with the chatbot.</param>
        public CyberSecurityChatBot(string userName)
        {
            UserName = userName;
        }

        /// <summary>
        /// Starts the interactive chat session.
        /// Displays available options and processes user input until 'exit' is typed.
        /// </summary>
        public void StartChat()
        {
            while (true)
            {
                // Display chatbot options header
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n====================================");
                Console.WriteLine(" Options: ");
                Console.WriteLine("====================================");
                Console.ResetColor();

                // Enable UTF-8 encoding to support special characters like emojis
                Console.OutputEncoding = Encoding.UTF8;

                // Display available chatbot functionalities
                Console.WriteLine($"\n🔹 Hey {UserName}, let's explore cybersecurity together! 🔹");
                Console.WriteLine("💡 Here’s what you can do:");
                Console.WriteLine("📌 Type 'topics' to discover cybersecurity topics.");
                Console.WriteLine("❓ Ask me: 'How are you?', 'What is your purpose?', or 'What can I ask you about?'.");
                Console.WriteLine("🚪 Type 'exit' anytime to leave the chat.");

                // Change user input prompt color for better visibility
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("You: ");
                Console.ResetColor();

                try
                {
                    // Read user input and handle empty cases
                    string userInput = Console.ReadLine()?.Trim() ?? "";
                    if (string.IsNullOrEmpty(userInput))
                    {
                        ConsoleUI.Respond("I didn't quite understand that. Could you please rephrase?");
                        continue;
                    }

                    // Convert input to lowercase for uniform processing
                    userInput = userInput.ToLower();

                    // Handle exit command
                    if (userInput == "exit")
                    {
                        ConsoleUI.Respond($"Hey {UserName}, stay vigilant and protect your online presence! Have a great day!");
                        break;
                    }
                    // Display cybersecurity topics if requested
                    else if (userInput == "topics")
                    {
                        ShowTopics();
                    }
                    // Process other user queries
                    else
                    {
                        ConsoleUI.Respond(ResponseGenerator.GenerateResponse(userInput));
                    }
                }
                catch (Exception ex)
                {
                    // Catch unexpected errors and inform the user
                    ConsoleUI.Respond($"Oops! Something went wrong. Please try again. (Error: {ex.Message})");
                }
            }
        }

        /// <summary>
        /// Displays a list of available cybersecurity topics the chatbot can discuss.
        /// </summary>
        private void ShowTopics()
        {
            ConsoleUI.Respond("\n📚 **I can help with the following topics:**\n" +
                              "- 🎣 **Phishing emails** (How to avoid scams)\n" +
                              "- 🔑 **Strong password practices** (Stay secure online)\n" +
                              "- 🚨 **Recognizing suspicious links** (Don't get hacked!)\n" +
                              "- 🌍 **Safe browsing tips** (Browse the web securely)");
        }
    }
}
