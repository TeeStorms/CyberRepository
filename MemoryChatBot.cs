using System;
using System.Collections.Generic;
using System.Text;

namespace CyberAwarenessBot
{
    public class MemoryChatBot : ChatBot
    {
        private readonly UserMemory _userMemory = new UserMemory();
        private string _currentTopic = null;
        private static readonly Random random = new Random();
        private string _currentMood = null;

        private static readonly Dictionary<string, List<string>> TopicResponses = new Dictionary<string, List<string>>
        {
            { "password", new List<string> {
                "🔐 **Passphrase Power:** Use longer phrases that are easy to remember but hard to guess.",
                "💡 **Password Variety:** Don't use the same password for multiple websites or apps.",
                "🛡️ **Consider a Manager:** A password manager can generate and store strong, unique passwords for you."
            }},
            { "scam", new List<string> {
                "🚨 **Urgency Alert:** Be wary of messages that pressure you to act immediately.",
                "📵 **Unsolicited Contact:** Don't trust unexpected calls or messages asking for personal details.",
                "💬 **Verify Authenticity:** If in doubt, independently verify the sender's legitimacy."
            }},
            { "privacy", new List<string> {
                "🔒 **App Permissions:** Review and limit the permissions you grant to mobile apps.",
                "👀 **Social Media Footprint:** Be mindful of what you share publicly on social media.",
                "⚙️ **Browser Extensions:** Regularly check and remove unnecessary or suspicious browser extensions."
            }},
            { "phishing", new List<string> {
                "📨 **Check for Errors:** Phishing emails often contain typos and grammatical mistakes.",
                "🔗 **Inspect Links:** Before clicking, hover over links to see where they actually lead.",
                "👁️‍🗨️ **Sensitive Info Request:** Legitimate organizations rarely ask for sensitive data via email."
            }},
            { "general", new List<string> {
                "✅ **Stay Updated:** Keep your software and devices updated to patch security vulnerabilities.",
                "⚠️ **Think Before You Click:** Be cautious of suspicious links and attachments.",
                "🛡️ **Use Strong Security:** Enable features like two-factor authentication whenever possible."
            }},
            { "basics", new List<string> {
                "🔑 **Strong Passwords Matter:** Use a combination of characters and avoid common words.",
                "🎣 **Beware of Phishing:** Don't share sensitive information via email or untrusted websites.",
                "🔒 **Keep Private Info Private:** Be mindful of what personal details you share online."
            }}
        };

        public MemoryChatBot(string name) : base(name) { }

        public override void DisplayWelcomeMessage()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Respond($"👋 Hi {UserName}! I’m your Cyber Awareness Bot. How are you feeling about online safety today?");
        }

        protected override void HandleInitialSentiment(string feeling)
        {
            string mood = SentimentAnalyzer.AnalyzeMoodCategory(feeling);
            if (mood != "neutral")
            {
                _currentMood = mood;
                switch (_currentMood)
                {
                    case "worried":
                        Respond("😟 I sense you're feeling a bit worried. Let's address those concerns together with three fundamental tips:");
                        RespondWithPoints("basics");
                        break;
                    case "confused":
                        Respond("🤔 It's alright to feel confused. Let's clarify things by looking at three key aspects of a core topic. Which one would you like to start with: Passwords, Scams, Privacy, or Phishing?");
                        break;
                    case "curious":
                        Respond("🧐 That's excellent! Let's explore that curiosity with three key points. Which topic are you most interested in: Passwords, Scams, Privacy, or Phishing?");
                        break;
                    case "frustrated":
                        Respond("😠 I'm sorry you're feeling frustrated. Let's try to simplify things with three quick tips on a key area. How about we start with password safety?");
                        RespondWithPoints("password");
                        break;
                    case "sad":
                        Respond("😔 I understand. Let's focus on some positive steps you can take to protect yourself online with three basic tips:");
                        RespondWithPoints("basics");
                        break;
                    case "happy":
                        Respond("😊 That's wonderful! Here are three important reminders to stay safe online:");
                        RespondWithPoints("general");
                        break;
                    default:
                        Respond($"😊 Thanks for sharing how you feel. What cybersecurity topic are you interested in learning about in three key points?");
                        break;
                }
            }
            else
            {
                Respond("😊 Thanks for sharing! What cybersecurity topics are on your mind today? You can ask me for three key points on Passwords, Scams, Privacy, or Phishing.");
            }
        }

        protected override void HandleTopics()
        {
            Respond("🔎 You can ask me about: Passwords, Scams, Privacy, or Phishing to learn three key points about each!");
        }

        protected override void HandleSentiment(string userInput)
        {
            if (string.IsNullOrEmpty(userInput))
            {
                Respond("😶 I didn't catch anything. Could you please type something?");
                return;
            }

            string mood = SentimentAnalyzer.AnalyzeMoodCategory(userInput);
            if (mood != "neutral")
            {
                _currentMood = mood;
                switch (_currentMood)
                {
                    case "worried":
                        Respond("It's understandable to feel worried. Here are three important things to remember about online safety:");
                        RespondWithPoints("basics");
                        break;
                    case "curious":
                        Respond("That's great! Which of these topics are you most curious about: Passwords, Scams, Privacy, or Phishing?");
                        break;
                    case "confused":
                        Respond("It's perfectly alright to feel confused. Let's focus on three key aspects of a core topic. Which one would you like to discuss?");
                        break;
                    case "frustrated":
                        Respond("I'm sorry you're feeling frustrated. Let's try to simplify things with three quick tips on a key area.");
                        RespondWithPoints("general");
                        break;
                    case "sad":
                        Respond("I understand. Let's focus on some positive steps you can take to protect yourself online with three basic tips:");
                        RespondWithPoints("basics");
                        break;
                    case "happy":
                        Respond("That's wonderful! Here are three important reminders to stay safe online:");
                        RespondWithPoints("general");
                        break;
                    default:
                        Respond($"Thanks for sharing how you feel. What cybersecurity topic are you interested in learning about in three key points?");
                        break;
                }
                return;
            }

            if (userInput.Contains("my name is"))
            {
                var name = userInput.Substring(userInput.IndexOf("my name is") + 10).Trim();
                _userMemory.Remember("name", name);
                Respond($"🙌 Nice to meet you, {name}! I’ll remember that.");
                return;
            }

            if (userInput.Contains("i'm interested in"))
            {
                var topic = userInput.Substring(userInput.IndexOf("i'm interested in") + 17).Trim().ToLower();
                _userMemory.Remember("topic", topic);
                _currentTopic = topic;
                RespondWithPoints(topic);
                return;
            }

            if (userInput.Contains("tell me about my interest"))
            {
                var topic = _userMemory.Recall("topic");
                if (!string.IsNullOrEmpty(topic))
                {
                    Respond($"📚 Based on your interest in {topic}, here are three key points:");
                    RespondWithPoints(topic);
                }
                else
                {
                    Respond("🤔 I don’t know your interests yet. Tell me what you’re interested in learning about in three key points!");
                }
                return;
            }

            var sentimentResponse = SentimentAnalyzer.AnalyzeMood(userInput);
            if (!string.IsNullOrEmpty(sentimentResponse))
            {
                Respond(sentimentResponse);
                return;
            }

            foreach (var topic in TopicResponses.Keys)
            {
                if (userInput.Contains(topic))
                {
                    _currentTopic = topic;
                    var name = _userMemory.Recall("name");
                    string greeting = string.IsNullOrEmpty(name) ? "" : $"{name}, ";
                    Respond($"{greeting}Here are three key things to know about {topic.ToUpper()}:");
                    RespondWithPoints(topic);
                    return;
                }
            }

            if (userInput.Contains("more") || userInput.Contains("explain"))
            {
                if (!string.IsNullOrEmpty(_currentTopic))
                {
                    var points = TopicResponses[_currentTopic];
                    Respond("Let me elaborate with another key point: " + points[random.Next(points.Count)]);
                }
                else
                {
                    Respond("💭 Could you remind me which topic you'd like to know more about?");
                }
                return;
            }

            Respond("🤔 I'm not quite sure I follow. You can ask about passwords, scams, privacy, or phishing to get three key points on each.");
        }

        private void RespondWithPoints(string topic)
        {
            if (TopicResponses.ContainsKey(topic))
            {
                Respond($"Here are three key things to know about {topic.ToUpper()}:");
                foreach (var point in TopicResponses[topic])
                {
                    Respond($"- {point}");
                }
            }
            else
            {
                Respond($"🛡️ I don't have specific key points for '{topic}' right now, but I'm always learning!");
            }
        }

        private string GetRandomResponse(string topic)
        {
            if (TopicResponses.ContainsKey(topic))
            {
                var list = TopicResponses[topic];
                return list[random.Next(list.Count)];
            }
            return "🛡️ I don't have information on that topic yet, but I'm always learning!";
        }
    }
}
