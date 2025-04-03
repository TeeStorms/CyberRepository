using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberAwarenessBot
{
    // User Interface Class
    class ConsoleUI
    {
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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nPress any key to continue...");
            Console.ResetColor();
            Console.ReadKey(true);
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
        }

        public static void AskUserName(out string name)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please enter your name:");
            name = Console.ReadLine()?.Trim() ?? "User";
            Console.ResetColor();
            Console.WriteLine("\n==================================================");
        }

        public static void Respond(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nChatbot: {message}\n");
            Console.ResetColor();
        }
    }
}
