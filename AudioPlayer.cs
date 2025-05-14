using System;
using System.IO;
using System.Media;
using System.Threading;

namespace CyberAwarenessBot
{
    public static class AudioPlayer // Made the class static as it only contains a static method
    {
        private static readonly string AudioFilePath = Path.Combine("audio.wav"); // Renamed for clarity

        /// <summary>
        /// Plays a welcome audio file (if available) and displays a welcome message with a typing effect.
        /// </summary>
        public static void PlayWelcomeAudio()
        {
            if (File.Exists(AudioFilePath))
            {
                try
                {
                    using (SoundPlayer player = new SoundPlayer(AudioFilePath)) // Using 'using' for proper resource disposal
                    {
                        player.Play();

                        string welcomeMessage = "Hello! 👋 Welcome to the Cybersecurity Awareness Bot! I'm here to help you stay safe online. 🛡️"; // Added emojis for engagement
                        foreach (char c in welcomeMessage)
                        {
                            Console.Write(c);
                            Thread.Sleep(50); // Slightly faster typing effect
                        }
                        Console.WriteLine();
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; // Indicate a warning
                    Console.WriteLine($"⚠️ Error playing audio: {ex.Message}");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("🔇 Welcome audio file not found."); // More descriptive message
                Console.ResetColor();
            }
        }
    }
}