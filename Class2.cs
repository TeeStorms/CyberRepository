using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberAwarenessBot
{

    // Abstract base class for chatbot functionalities
    // ChatBot Class
    abstract class ChatBot
    {
        private string UserName;
        public abstract void DisplayWelcomeMessage();
        public ChatBot(string name)
        {
            UserName = name;
        }

        public void StartChat(string userName)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n====================================");
                Console.WriteLine(" Options: ");
                Console.WriteLine("====================================");
                Console.ResetColor();

                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine($"\n🔹 Hey {UserName}, let's explore cybersecurity together! 🔹");
                Console.WriteLine("💡 Here’s what you can do:");
                Console.WriteLine("📌 Type 'topics' to discover cybersecurity topics.");
                Console.WriteLine("❓ Ask me anything cybersecurity-related!");
                Console.WriteLine("🚪 Type 'exit' to leave the chat.");
                Console.Write("You: ");

                string userInput = Console.ReadLine().Trim().ToLower();
                if (string.IsNullOrEmpty(userInput))
                {
                    Respond("I didn't quite understand that. Could you please rephrase?");
                    continue;
                }

                if (userInput == "exit")
                {
                    Respond($"Hey {UserName}, stay safe online! Have a great day!");
                    break;
                }
                else
                {
                    string response = ResponseGenerator.GenerateResponse(userInput);
                    Respond(response);
                }
            }
        }

        private void Respond(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nChatbot: {message}\n");
            Console.ResetColor();
        }
    }

}
