using System;
using System.Text;

namespace CyberAwarenessBot
{
    // Abstract base class for chatbot functionalities
    public abstract class ChatBot
    {
        // Protected property to store the user's name
        protected string UserName { get; private set; }

        // Constructor to initialize the user's name
        protected ChatBot(string name)
        {
            UserName = name;
        }

        /// <summary>
        /// Abstract method to display a welcome message.
        /// Must be implemented by derived classes.
        /// </summary>
        public abstract void DisplayWelcomeMessage();

        /// <summary>
        /// Starts an interactive chat session with the user, prioritizing understanding their initial feelings.
        /// Displays options and processes user input in a loop until the user exits.
        /// </summary>
        public virtual void StartChat()
        {
            DisplayWelcomeMessage();

            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine(" 😊 Before we begin, how are you feeling today?"); // Initial question about feelings
            Console.WriteLine(" (e.g., 'I'm feeling curious', 'I'm a bit worried')");
            Console.WriteLine(new string('=', 50));
            Console.Write("You: ");
            string initialFeeling = Console.ReadLine()?.Trim().ToLower();
            HandleInitialSentiment(initialFeeling); // New method to process initial sentiment

            while (true)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("\n" + new string('=', 40));
                Console.WriteLine(" 💬 How can I help you with cybersecurity today? ");
                Console.WriteLine(new string('=', 40));
                Console.WriteLine("📌 Type 'topics' to see what I can talk about.");
                Console.WriteLine("👋 You can also tell me your name or interests.");
                Console.WriteLine("🔑 Ask me about passwords, scams, privacy, or phishing for helpful tips.");
                Console.WriteLine("🎲 Type 'phishing tip' for random advice.");
                Console.WriteLine("😊 Share your thoughts or concerns.");
                Console.WriteLine("❓ Got a cybersecurity question? Just ask!");
                Console.WriteLine("🚪 Type 'exit' to leave. Stay safe! 🚀");
                Console.Write("You: ");

                string userInput = Console.ReadLine()?.Trim().ToLower();
     
                if (string.IsNullOrEmpty(userInput))
                {
                    Respond("🤔 Hmm, I didn't catch that. Could you say it again?");
                    continue;
                }

                if (userInput == "exit")
                {
                    Respond($"👋 Goodbye {UserName}! Remember, staying cyber-aware is an ongoing journey! 🚀 Stay safe out there!");
                    break;
                }
                else if (userInput == "topics")
                {
                    HandleTopics();
                }
                else if (userInput == "phishing tip")
                {
                    // Provide a random phishing tip if available
                    if (this is CyberSecurityChatBot csBot && csBot.keywordResponses.ContainsKey("phishing"))
                    {
                        var tips = csBot.keywordResponses["phishing"];
                        var tip = tips[new Random().Next(tips.Count)];
                        Respond($"🎣 Phishing Tip: {tip}");
                    }
                    else
                    {
                        Respond("Sorry, I don't have phishing tips available right now.");
                    }
                }
                else if (userInput.StartsWith("my name is "))
                {
                    var name = userInput.Substring("my name is ".Length).Trim();
                    if (!string.IsNullOrEmpty(name))
                    {
                        Console.OutputEncoding = Encoding.UTF8;
                        UserName = char.ToUpper(name[0]) + name.Substring(1);
                        Respond($"Nice to meet you, {UserName}! How can I help you with cybersecurity today?");
                    }
                    else
                    {
                        Respond("I didn't catch your name. Could you please repeat?");
                    }
                }
                else if (userInput.StartsWith("i am interested in "))
                {
                    var interest = userInput.Substring("i am interested in ".Length).Trim();
                    if (this is CyberSecurityChatBot csBot)
                    {
                        csBot.AddInterest(interest);
                    }
                    Respond($"Great! I'll remember your interest in {interest}. Would you like to hear some tips or explore related topics?");
                }
                else
                {
                    // If the input doesn't match any command, handle as a general sentiment/question
                    HandleSentiment(userInput);
                }
            }
        }

        /// <summary>
        /// Abstract method to handle the user's initial expression of feeling.
        /// Must be implemented by derived classes.
        /// </summary>
        protected abstract void HandleInitialSentiment(string feeling);

        /// <summary>
        /// Hook for handling topics. Must be implemented by derived classes.
        /// </summary>
        protected abstract void HandleTopics();

        /// <summary>
        /// Hook for handling sentiment during the chat. Must be implemented by derived classes.
        /// </summary>
        /// <param name="userInput">The user's input.</param>
        protected abstract void HandleSentiment(string userInput);

        /// <summary>
        /// Displays the chatbot's response in a distinct color for readability.
        /// </summary>
        /// <param name="message">The response message to display.</param>
        protected void Respond(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n🤖 Chatbot: {message}\n");
            Console.ResetColor();
        }
    }
}