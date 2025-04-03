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
        private static readonly string audioFilePath = Path.Combine("audio.wav");

        public static void PlayWelcomeAudio()
        {
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
        }
    }
}
