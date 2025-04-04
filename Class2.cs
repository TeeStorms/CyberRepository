using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberAwarenessBot
{
    // Abstract base class for chatbot functionalities
    abstract class ChatBot
    {
        // Private field to store the user's name
        private string UserName;

        /// <summary>
        /// Abstract method to display a welcome message. 
        /// Must be implemented by derived classes.
        /// </summary>
        public abstract void DisplayWelcomeMessage();

        /// <summary>
        /// Constructor to initialize the chatbot with a username.
        /// </summary>
        /// <param name="name">The name of the user interacting with the chatbot.</param>
        public ChatBot(string name)
        {
            UserName = name;
        }

        /// <summary>
        /// Starts an interactive chat session with the user.
        /// Displays options and processes user input in a loop until the user exits.
        /// </summary>
        /// <param name="userName">The name of the user.</param>
        public void StartChat(string userName)
        {
            while (true)
            {
                // Display chat menu options
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n====================================");
                Console.WriteLine(" Options: ");
                Console.WriteLine("====================================");
                Console.ResetColor();

                // Set console encoding to support special characters (like emojis)
                Console.OutputEncoding = Encoding.UTF8;

                // Display interactive chatbot prompt with available options
                Console.WriteLine($"\n🔹 Hey {UserName}, let's explore cybersecurity together! 🔹");
                Console.WriteLine("💡 Here’s what you can do:");
                Console.WriteLine("📌 Type 'topics' to discover cybersecurity topics.");
                Console.WriteLine("❓ Ask me anything cybersecurity-related!");
                Console.WriteLine("🚪 Type 'exit' to leave the chat.");
                Console.Write("You: ");

                // Read and process user input
                string userInput = Console.ReadLine().Trim().ToLower();

                // Handle empty input
                if (string.IsNullOrEmpty(userInput))
                {
                    Respond("I didn't quite understand that. Could you please rephrase?");
                    continue;
                }

                // Exit chat if the user types 'exit'
                if (userInput == "exit")
                {
                    Respond($"Hey {UserName}, stay safe online! Have a great day!");
                    break;
                }
                else
                {
                    // Generate a response based on the user's input
                    string response = ResponseGenerator.GenerateResponse(userInput);
                    Respond(response);
                }
            }
        }

        /// <summary>
        /// Displays the chatbot's response in blue text for readability.
        /// </summary>
        /// <param name="message">The response message to display.</param>
        private void Respond(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nChatbot: {message}\n");
            Console.ResetColor();
        }
    }
}
