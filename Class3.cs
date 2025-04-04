using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CyberAwarenessBot
{
    class AudioPlayer
    {
        // Define the path to the audio file
        private static readonly string audioFilePath = Path.Combine("audio.wav");

        /// <summary>
        /// Plays a welcome audio file (if available) and displays a welcome message with a typing effect.
        /// </summary>
        public static void PlayWelcomeAudio()
        {
            // Check if the welcome audio file exists in the specified path
            if (File.Exists(audioFilePath))
            {
                try
                {
                    // Initialize the SoundPlayer with the audio file and play it
                    SoundPlayer player = new SoundPlayer(audioFilePath);
                    player.Play();

                    // Define the welcome message to be displayed
                    string welcomeMessage = "Hello! Welcome to the Cybersecurity Awareness Bot! I'm here to help you stay safe online.";

                    // Simulate a typing effect for better user experience
                    foreach (char c in welcomeMessage)
                    {
                        Console.Write(c);
                        Thread.Sleep(79); // Delay each character to create a typing effect
                    }
                    Console.WriteLine(); // Move to the next line after displaying the message
                }
                catch (Exception ex)
                {
                    // Handle any errors that may occur while playing the audio
                    Console.WriteLine($"Error playing audio: {ex.Message}");
                }
            }
            else
            {
                // Notify the user if the audio file is missing
                Console.WriteLine("\nOops! Audio file not found.");
            }
        }
    }
}
