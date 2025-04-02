using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CyberAwarenessBot
{
    class Program
    {
        // Main method that runs the CyberAwarenessBot
        static void Main(string[] args)
        {
            // Clear console and set background and text colors for a better user interface
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            // Display a prompt asking the user to maximize the window for better experience
            Console.WriteLine("\n====================================================");
            Console.WriteLine("|    For the best experience, please maximize your  |");
            Console.WriteLine("|    window before continuing the application.      |");
            Console.WriteLine("====================================================");
            Console.ResetColor();

            // Prompt user to press any key to proceed
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nPress any key to continue...");
            Console.ResetColor();
            Console.ReadKey(true); // Waits for user input

            // Clear console and display the welcome message
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n==================================================");
            Console.WriteLine("|          WELCOME TO YOUR CYBERSECURITY ASSISTANT! |");
            Console.WriteLine("==================================================");
            Console.ResetColor();

            // Display ASCII art related to cybersecurity awareness
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
           Fight Bugs                      |     |
                                \\_V_//
                                \/=|=\/
                                 [=v=]
                               __\___/_____
                              /..[  _____  ]
                             /_  [ [  M /] ]
                            /../.[ [ M /@] ]
                           <-->[_[ [M /@/] ]
                          /../ [.[ [ /@/ ] ]
     _________________]\ /__/  [_[ [/@/ C] ]
    <_________________>>0---]  [=\ \@/ C / /   
       ___      ___   ]/000o   /__\ \ C / /    
          \    /              /....\ \_/ /     
       ....\||/....           [___/=\___/     
      .    .  .    .          [...] [...]    
     .      ..      .         [___/ \___]     
     .    0 .. 0    .         <---> <--->    
  /\/\.    .  .    ./\/\      [..]   [..]    
 / / / .../|  |\... \ \ \    _[__]   [__]_   
/ / /       \/       \ \ \  [____>   <____]                                                     
            ");
            Console.ResetColor();

            // Path to the audio file for a welcoming sound
            string audioFilePath = Path.Combine("audio.wav");

            // Check if the audio file exists and play it
            if (File.Exists(audioFilePath))
            {
                try
                {
                    // Create a SoundPlayer object to play the audio
                    SoundPlayer player = new SoundPlayer(audioFilePath);
                    player.Play();

                    // Simulate a typing effect for the welcome message
                    string welcomeMessage = "Hello! Welcome to the Cybersecurity Awareness Bot! I'm here to help you stay safe online.";
                    foreach (char c in welcomeMessage)
                    {
                        Console.Write(c);
                        Thread.Sleep(79); // Typing delay for effect
                    }
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    // Handle any errors when trying to play the audio
                    Console.WriteLine($"Error playing audio: {ex.Message}");
                }
            }
            else
            {
                // If the audio file doesn't exist, inform the user
                Console.WriteLine("\nOops! Audio file not found.");
            }

            // Display a motivational message for the user
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n====================================================");
            Console.WriteLine("|      Ready to protect your digital world,       |");
            Console.WriteLine("|      let's dive into cybersecurity tips!        |");
            Console.WriteLine("====================================================");
            Console.ResetColor();

            // Ask the user to input their name for personalization
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please enter your name:");
            string name = Convert.ToString(Console.ReadLine());
            Console.ResetColor();
            Console.WriteLine("\n==================================================");

            // Start the chatbot conversation
            StartTextChat(name);

            // Play a beep sound when the chatbot session ends
            Console.Beep();
        }

        // Method to start the text-based chatbot conversation
        static void StartTextChat(string name)
        {
            while (true)
            {
                // Display chatbot options for user interaction
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n====================================");
                Console.WriteLine(" Options: ");
                Console.WriteLine("====================================");
                Console.ResetColor();

                // Set console encoding to UTF-8 to support symbols and emojis
                Console.OutputEncoding = Encoding.UTF8;

                // Display available chatbot functionalities and tips for user interaction
                Console.WriteLine($"\n🔹 Hey {name}, let's explore cybersecurity together! 🔹");
                Console.WriteLine("💡 Here’s what you can do:");
                Console.WriteLine("📌 Type 'topics' to discover cybersecurity topics.");
                Console.WriteLine("❓ Ask me: 'How are you?', 'What is your purpose?', or 'What can I ask you about?'.");
                Console.WriteLine("🚪 Type 'exit' anytime to leave the chat.");

                // Prompt user for input
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("You: ");
                Console.ResetColor();

                try
                {
                    string userInput = Console.ReadLine().Trim();

                    // If user input is empty, prompt them to enter a valid response
                    if (string.IsNullOrEmpty(userInput))
                    {
                        Respond("I didn't quite understand that. Could you please rephrase?");
                        continue;
                    }

                    userInput = userInput.ToLower();

                    // Exit condition for chatbot session
                    if (userInput == "exit")
                    {
                        Respond($"Hey {name}, stay vigilant and protect your online presence! Have a great day!");
                        break;
                    }
                    // Show available topics
                    else if (userInput == "topics")
                    {
                        ShowTopics();
                    }
                    else
                    {
                        // Generate and display response based on user input
                        string response = GenerateResponse(userInput);
                        Respond(response);
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors during user interaction
                    Respond($"Oops! Something went wrong. Please try again. (Error: {ex.Message})");
                }
            }
        }

        // Generate a response based on user input
        static string GenerateResponse(string userInput)
        {
            try
            {
                userInput = userInput.ToLower(); // Ensure case-insensitivity

                // Responses to various cybersecurity-related topics
                if (userInput.Contains("phishing") || userInput.Contains("email"))
                {
                    return "🚨 **Phishing Scams Warning!**\n" +
                           "- ⚠️ Beware of emails that create **urgency**.\n" +
                           "- 🔗 **Never** click on suspicious links.\n" +
                           "- 📧 Always verify the sender's email address.";
                }
                else if (userInput.Contains("password"))
                {
                    return "🔑 **Strong Password Practices:**\n" +
                           "- Use at least **12 characters**.\n" +
                           "- Mix **uppercase, lowercase, numbers, and symbols**.\n" +
                           "- Avoid common words and predictable patterns.";
                }
                else if (userInput.Contains("link") || userInput.Contains("suspicious"))
                {
                    return "🔗 **Avoid Suspicious Links:**\n" +
                           "- 🚫 Never click on unverified links.\n" +
                           "- 🛡️ Hover over links to preview the destination before clicking.\n" +
                           "- 🔍 Use a **URL checker** to verify safety.";
                }
                else if (userInput.Contains("safe browsing") || userInput.Contains("online safety"))
                {
                    return "🌍 **Safe Browsing Tips:**\n" +
                           "- 🔒 Use **HTTPS** websites for secure connections.\n" +
                           "- 🛑 Avoid downloading files from **unknown sources**.\n" +
                           "- 🕵️‍♂️ Use a **trusted ad-blocker** to prevent malicious ads.";
                }
                else if (userInput.Contains("how are you"))
                {
                    return "😊 I'm just a chatbot, but I'm here and ready to assist you!";
                }
                else if (userInput.Contains("purpose"))
                {
                    return "🤖 **My Purpose:**\n" +
                           "- 🛡️ Provide cybersecurity **tips and best practices**.\n" +
                           "- 🔍 Help you recognize **online threats**.\n" +
                           "- 🚀 Keep you safe in the digital world!";
                }
                else if (userInput.Contains("ask about"))
                {
                    return "🔑 **Topics I can help with:**\n" +
                           "        - 🚨 **Phishing Scams**\n" +
                           "        - 🔑 **Strong Password Practices**\n" +
                           "        - 🔗 **Suspicious Links**\n" +
                           "        - 🌍 **Safe Browsing Tips**";
                }
                else
                {
                    return "I didn't quite understand that. Could you please rephrase?";
                }
            }
            catch (Exception ex)
            {
                return $"⚠️ Oops! I encountered an issue. (Error: {ex.Message})";
            }
        }

        // Display the list of available topics for the user to explore
        static void ShowTopics()
        {
            Respond("\n📚 **I can help with the following topics:**\n" +
                    "- 🎣 **Phishing emails** (How to avoid scams)\n" +
                    "- 🔑 **Strong password practices** (Stay secure online)\n" +
                    "- 🚨 **Recognizing suspicious links** (Don't get hacked!)\n" +
                    "- 🌍 **Safe browsing tips** (Browse the web securely)");
        }

        // Respond method to output chatbot messages with a specific color
        static void Respond(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nChatbot: {message}\n");
            Console.ResetColor();
        }
    }
}
