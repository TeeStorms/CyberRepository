using System.Collections.Generic;
using System;

class ResponseGenerator
{
    public delegate string ResponseDelegate();

    static Random rand = new Random();

    static Dictionary<string, ResponseDelegate> keywordResponses = new Dictionary<string, ResponseDelegate>()
    {
        { "password", () => "🔑 Use complex, unique passwords for each account." },
        { "scam", () => "🚨 Watch out for scams. Don't click unknown links!" },
        { "privacy", () => "🔐 Protect your personal information online." },
        { "phishing", () => GetRandomPhishingTip() }
    };

    // List of phishing tips
    private static readonly List<string> phishingTips = new List<string>()
    {
        "📧 Be cautious of emails asking for credentials.",
        "⚠️ Don't click links from unknown senders.",
        "🔍 Hover over links to check if the URL is legitimate.",
        "🕵️ Double-check the sender's email address for misspellings.",
        "📨 Avoid downloading attachments from unknown sources.",
        "🔒 Use two-factor authentication to protect your accounts."
    };

    // Method to return a random phishing tip
    private static string GetRandomPhishingTip()
    {
        int index = rand.Next(phishingTips.Count);
        return phishingTips[index];
    }

    public static string GenerateResponse(string userInput)
    {
        try
        {
            userInput = userInput.ToLower();
            foreach (var pair in keywordResponses)
            {
                if (userInput.Contains(pair.Key))
                    return pair.Value();
            }
            return "🤖 I'm still learning. Please ask about a cybersecurity topic!";
        }
        catch (Exception ex)
        {
            return $"⚠️ Oops! I encountered an issue. (Error: {ex.Message})";
        }
    }
}
