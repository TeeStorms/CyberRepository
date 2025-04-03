using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberAwarenessBot
{
    // Handles chatbot responses
    // Response Generator Class
    class ResponseGenerator
    {
        public static string GenerateResponse(string userInput)
        {
            try
            {
                userInput = userInput.ToLower(); // Ensure case-insensitivity

                // Response for phishing-related queries
                if (userInput.Contains("phishing") || userInput.Contains("email"))
                {
                    return "🚨 **Phishing Scams Warning!**\n" +
                           "- ⚠️ Beware of emails that create **urgency**.\n" +
                           "- 🔗 **Never** click on suspicious links.\n" +
                           "- 📧 Always verify the sender's email address.";
                }
                // Response for password-related queries
                else if (userInput.Contains("password"))
                {
                    return "🔑 **Strong Password Practices:**\n" +
                           "- Use at least **12 characters**.\n" +
                           "- Mix **uppercase, lowercase, numbers, and symbols**.\n" +
                           "- Avoid common words and predictable patterns.";
                }
                // Response for suspicious links
                else if (userInput.Contains("link") || userInput.Contains("suspicious"))
                {
                    return "🔗 **Avoid Suspicious Links:**\n" +
                           "- 🚫 Never click on unverified links.\n" +
                           "- 🛡️ Hover over links to preview the destination before clicking.\n" +
                           "- 🔍 Use a **URL checker** to verify safety.";
                }
                // Response for safe browsing
                else if (userInput.Contains("safe browsing") || userInput.Contains("online safety"))
                {
                    return "🌍 **Safe Browsing Tips:**\n" +
                           "- 🔒 Use **HTTPS** websites for secure connections.\n" +
                           "- 🛑 Avoid downloading files from **unknown sources**.\n" +
                           "- 🕵️‍♂️ Use a **trusted ad-blocker** to prevent malicious ads.";
                }
                // Response for chatbot's well-being query
                else if (userInput.Contains("how are you"))
                {
                    return "😊 I'm just a chatbot, but I'm here and ready to assist you!";
                }
                // Response for chatbot's purpose query
                else if (userInput.Contains("purpose"))
                {
                    return "🤖 **My Purpose:**\n" +
                           "- 🛡️ Provide cybersecurity **tips and best practices**.\n" +
                           "- 🔍 Help you recognize **online threats**.\n" +
                           "- 🚀 Keep you safe in the digital world!";
                }
                else if (userInput.Contains("ask about"))
                {
                    return "🔑 **Strong Password Practices:**\n" +
                           "        - 🚨 **Phishing Scams Warning!**\n" +
                           "        - 🔗 **Suspicious Links:**\n" +
                           "        - 🌍 **Safe Browsing Tips:**";
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
    }
}

