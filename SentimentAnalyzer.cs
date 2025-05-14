using System.Collections.Generic;

namespace CyberAwarenessBot
{
    public static class SentimentAnalyzer
    {
        private static readonly Dictionary<string, string> SentimentResponses = new Dictionary<string, string>
        {
            { "worried", "It's okay to feel worried. Let's go over some tips to stay safe online." },
            { "curious", "Curiosity is great! Let's explore more about cybersecurity together." },
            { "frustrated", "It's okay to feel frustrated. Let's simplify things and make it easier for you." },
            { "confident", "That's great to hear! Confidence is key to staying secure online." }
        };

        // New: Enhanced mood category detection
        public static string AnalyzeMoodCategory(string text)
        {
            string lowerText = text.ToLower();

            if (lowerText.Contains("worried") || lowerText.Contains("anxious") || lowerText.Contains("nervous") || lowerText.Contains("concerned") || lowerText.Contains("afraid"))
            {
                return "worried";
            }
            else if (lowerText.Contains("curious") || lowerText.Contains("interested") || lowerText.Contains("eager") || lowerText.Contains("intrigued"))
            {
                return "curious";
            }
            else if (lowerText.Contains("confused") || lowerText.Contains("unsure") || lowerText.Contains("don't understand") || lowerText.Contains("puzzled"))
            {
                return "confused";
            }
            else if (lowerText.Contains("frustrated") || lowerText.Contains("annoyed") || lowerText.Contains("irritated") || lowerText.Contains("upset"))
            {
                return "frustrated";
            }
            else if (lowerText.Contains("sad") || lowerText.Contains("unhappy") || lowerText.Contains("down"))
            {
                return "sad";
            }
            else if (lowerText.Contains("happy") || lowerText.Contains("glad") || lowerText.Contains("excited") || lowerText.Contains("positive"))
            {
                return "happy";
            }
            // Add more sentiment categories as needed
            else
            {
                return "neutral";
            }
        }

        // New: Use the category for richer responses
        public static string AnalyzeMood(string text)
        {
            string lowerText = text.ToLower();

            if (lowerText.Contains("that's helpful") || lowerText.Contains("thank you") || lowerText.Contains("great"))
            {
                return "😊 I'm glad I could help!";
            }
            else if (lowerText.Contains("i appreciate that"))
            {
                return "You're very welcome!";
            }
            // Add more general positive/negative feedback phrases
            return null;
        }



        // Old: Direct sentiment-to-response lookup (you can keep this for flexibility)
        public static string AnalyzeSentimentResponse(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }

            input = input.ToLower();

            foreach (var sentiment in SentimentResponses.Keys)
            {
                if (input.Contains(sentiment))
                {
                    return SentimentResponses[sentiment];
                }
            }

            return null; // No sentiment detected
        }
    }
}
