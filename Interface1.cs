using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberAwarenessBot
{
    // Handles the user interface interactions for the chatbot
    class ConsoleUI
    {
        // Displays the introductory message and cybersecurity-themed ASCII art
        public static void DisplayIntro()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n====================================================");
            Console.WriteLine("|    For the best experience, please maximize your  |");
            Console.WriteLine("|    window before continuing the application.      |");
            Console.WriteLine("====================================================");
            Console.ResetColor();

            // Prompt the user to press any key before continuing
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nPress any key to continue...");
            Console.ResetColor();
            Console.ReadKey(true);

            // Clear the console and display the welcome message
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n==================================================");
            Console.WriteLine("|          WELCOME TO YOUR CYBERSECURITY ASSISTANT! |");
            Console.WriteLine("==================================================");
            Console.ResetColor();

            // Display ASCII art representing cybersecurity awareness
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
        }

        // Asks the user for their name and ensures a valid response
        public static void AskUserName(out string name)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please enter your name:");
            name = Console.ReadLine()?.Trim() ?? "User";
            Console.ResetColor();
            Console.WriteLine("\n==================================================");
        }

        // Displays chatbot responses in blue text for better readability
        public static void Respond(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nChatbot: {message}\n");
            Console.ResetColor();
        }
    }
}
