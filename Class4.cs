using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberAwarenessBot
{
    // This class handles the generation of responses based on user input
    // It analyzes the input and returns a relevant cybersecurity tip or message
    class ResponseGenerator
    {
        // Main method that generates the appropriate response based on the user's input
        public static string GenerateResponse(string userInput)
        {
            try
            {
                // Convert user input to lowercase to ensure case-insensitive comparisons
                userInput = userInput.ToLower();

                // Response for phishing-related queries (e.g., phishing emails)
                if (userInput.Contains("phishing") || userInput.Contains("email"))
                {
                    return "🚨 **Phishing Scams Warning!**\n" +
                           "- ⚠️ Beware of emails that create **urgency**.\n" +
                           "- 🔗 **Never** click on suspicious links.\n" +
                           "- 📧 Always verify the sender's email address.";
                }
                // Response for password-related queries (e.g., best practices for strong passwords)
                else if (userInput.Contains("password"))
                {
                    return "🔑 **Strong Password Practices:**\n" +
                           "- Use at least **12 characters**.\n" +
                           "- Mix **uppercase, lowercase, numbers, and symbols**.\n" +
                           "- Avoid common words and predictable patterns.";
                }
                // Response for suspicious link-related queries (e.g., how to handle suspicious links)
                else if (userInput.Contains("link") || userInput.Contains("suspicious"))
                {
                    return "🔗 **Avoid Suspicious Links:**\n" +
                           "- 🚫 Never click on unverified links.\n" +
                           "- 🛡️ Hover over links to preview the destination before clicking.\n" +
                           "- 🔍 Use a **URL checker** to verify safety.";
                }
                // Response for queries related to safe browsing practices
                else if (userInput.Contains("safe browsing") || userInput.Contains("online safety"))
                {
                    return "🌍 **Safe Browsing Tips:**\n" +
                           "- 🔒 Use **HTTPS** websites for secure connections.\n" +
                           "- 🛑 Avoid downloading files from **unknown sources**.\n" +
                           "- 🕵️‍♂️ Use a **trusted ad-blocker** to prevent malicious ads.";
                }
                // Response for queries asking about the chatbot's well-being (e.g., 'How are you?')
                else if (userInput.Contains("how are you"))
                {
                    return "😊 I'm just a chatbot, but I'm here and ready to assist you!";
                }
                // Response for queries asking about the chatbot's purpose
                else if (userInput.Contains("purpose"))
                {
                    return "🤖 **My Purpose:**\n" +
                           "- 🛡️ Provide cybersecurity **tips and best practices**.\n" +
                           "- 🔍 Help you recognize **online threats**.\n" +
                           "- 🚀 Keep you safe in the digital world!";
                }
                // Response for queries asking for a summary of topics that can be asked about
                else if (userInput.Contains("ask about"))
                {
                    return "🔑 **You can ask about the following topics:**\n" +
                           "- 🚨 **Phishing Scams Warning!**\n" +
                           "- 🔗 **Suspicious Links**\n" +
                           "- 🌍 **Safe Browsing Tips**";
                }
                // Default response when no specific match is found
                else
                {
                    return "I didn't quite understand that. Could you please rephrase?";
                }
            }
            // Catch any exceptions that might occur and return an error message
            catch (Exception ex)
            {
                return $"⚠️ Oops! I encountered an issue. (Error: {ex.Message})";
            }
        }
    }
}
