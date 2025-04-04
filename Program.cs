using System;
using System.IO;
using System.Media;
using System.Text;
using System.Threading;

namespace CyberAwarenessBot
{
    /// <summary>
    /// Entry point of the Cyber Awareness Chatbot application.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method that initializes and starts the chatbot.
        /// </summary>
        static void Main()
        {
            // Display the chatbot introduction message
            ConsoleUI.DisplayIntro();

            // Play the welcome audio to enhance user engagement
            AudioPlayer.PlayWelcomeAudio();

            // Prompt the user to enter their name and store the input
            ConsoleUI.AskUserName(out string name);

            // Create an instance of the chatbot with the provided username
            CyberSecurityChatBot chatBot = new CyberSecurityChatBot(name);

            // Start the interactive chat session
            chatBot.StartChat();

            // Play a beep sound at the end of the session to signal exit
            Console.Beep();
        }
    }
}
