using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberAwarenessBot
{
    // Handles chatbot interaction and responses
    class CyberSecurityChatBot
    {
        private string UserName;

        public CyberSecurityChatBot(string userName)
        {
            UserName = userName;
        }

        public void StartChat()
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
                Console.WriteLine("❓ Ask me: 'How are you?', 'What is your purpose?', or 'What can I ask you about?'.");
                Console.WriteLine("🚪 Type 'exit' anytime to leave the chat.");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("You: ");
                Console.ResetColor();
                try
                {
                    string userInput = Console.ReadLine()?.Trim() ?? "";
                    if (string.IsNullOrEmpty(userInput))
                    {
                        ConsoleUI.Respond("I didn't quite understand that. Could you please rephrase?");
                        continue;
                    }
                    userInput = userInput.ToLower();
                    if (userInput == "exit")
                    {
                        ConsoleUI.Respond($"Hey {UserName}, stay vigilant and protect your online presence! Have a great day!");
                        break;
                    }
                    else if (userInput == "topics")
                    {
                        ShowTopics();
                    }
                    else
                    {
                        ConsoleUI.Respond(ResponseGenerator.GenerateResponse(userInput));
                    }
                }
                catch (Exception ex)
                {
                    ConsoleUI.Respond($"Oops! Something went wrong. Please try again. (Error: {ex.Message})");
                }
            }
        }

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
