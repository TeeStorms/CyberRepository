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
        static void Main(string[] args)
        {

            // Clear console and set colors for better readability
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            // Display an instruction for the user to maximize the window
            Console.WriteLine("\n====================================================");
            Console.WriteLine("|    For the best experience, please maximize your  |");
            Console.WriteLine("|    window before continuing the application.      |");
            Console.WriteLine("====================================================");
            Console.ResetColor();

            // Prompt user to press a key before proceeding
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nPress any key to continue...");
            Console.ResetColor();
            Console.ReadKey(true); // Waits for user input

            // Display welcome message
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n==================================================");
            Console.WriteLine("|          WELCOME TO YOUR CYBERSECURITY ASSISTANT! |");
            Console.WriteLine("==================================================");
            Console.ResetColor();


            // Display ASCII art related to cybersecurity
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

            // Path to the audio file
            string audioFilePath = Path.Combine("audio.wav");


            // Check if the welcome audio file exists
            if (File.Exists(audioFilePath))
            {
                try
                {
                    // Play audio if the file is found
                    SoundPlayer player = new SoundPlayer(audioFilePath);
                    player.Play();

                    // Type out welcome message with delay for a better user experience
                    string welcomeMessage = "Hello! Welcome to the Cybersecurity Awareness Bot! I'm here to help you stay safe online.";
                    foreach (char c in welcomeMessage)
                    {
                        Console.Write(c);
                        Thread.Sleep(79); // Simulate a typing effect
                    }
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error playing audio: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("\nOops! Audio file not found.");
            }

            // Display a motivational message for cybersecurity awareness
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n====================================================");
            Console.WriteLine("|      Ready to protect your digital world,       |");
            Console.WriteLine("|      let's dive into cybersecurity tips!        |");
            Console.WriteLine("====================================================");
            Console.ResetColor();

            // Ask user for their name
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please enter your name:");
            string name = Convert.ToString(Console.ReadLine());
            Console.ResetColor();
            Console.WriteLine("\n==================================================");

            / Start the chatbot conversation
            StartTextChat(name);

            // Play a beep sound when the chatbot session ends
            Console.Beep();
        }

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

                // Inform user of available chatbot functionalities
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
                    Respond($"Oops! Something went wrong. Please try again. (Error: {ex.Message})");
                }
            }
        }
    }
    }

