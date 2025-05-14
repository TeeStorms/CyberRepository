using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CyberAwarenessBot
{
    public class CyberSecurityChatBot : ChatBot
    {
        protected internal Dictionary<string, List<string>> keywordResponses = new Dictionary<string, List<string>>
        {
            { "password", new List<string> {
                "🔑 **Create Strong Passwords:** Use a mix of uppercase, lowercase, numbers, and symbols.",
                "🔒 **Unique Passwords:** Avoid reusing passwords across different online accounts.",
                "🛡️ **Password Manager:** Consider using a password manager to securely store complex passwords."
            }},
            { "scam", new List<string> {
                "🚨 **Be Skeptical:** Don't trust unsolicited messages asking for personal information.",
                "📧 **Verify Links:** Never click on suspicious links or download attachments from unknown senders.",
                "⚠️ **Too Good to Be True:** If an offer seems unbelievable, it's likely a scam."
            }},
            { "privacy", new List<string> {
                "🔐 **Review Privacy Settings:** Regularly check and adjust privacy settings on your online accounts.",
                "🕵️ **Limit Sharing:** Be mindful of the personal information you share online.",
                "🌐 **Secure Connections:** Use secure (HTTPS) websites, especially when entering sensitive data."
            }},
            { "phishing", new List<string> {
                "🎣 **Urgency is a Red Flag:** Be cautious of emails or messages that demand immediate action.",
                "📧 **Check Sender Details:** Always verify the sender's email address for inconsistencies.",
                "🔍 **Hover Before Clicking:** Hover your mouse over links to see the actual URL before clicking."
            }},
            { "basics", new List<string> {
                "🛡️ **Keep Software Updated:** Regularly update your operating system, browser, and antivirus software.",
                "🔥 **Use a Firewall:** Enable your firewall to help protect against unauthorized access.",
                "💾 **Backup Your Data:** Regularly back up important files in case of data loss."
            }},
            { "general", new List<string> {
                "🧠 **Stay Informed:** Keep learning about common cybersecurity threats and how to avoid them.",
                "🗣️ **Be Careful What You Share:** Think twice before posting personal information online.",
                "🌐 **Secure Your Network:** Use strong passwords for your Wi-Fi and consider a VPN on public networks."
            }}
        };

        private const string KeywordResponsesFile = "keywordResponses.json";
        private readonly Random random = new Random();
        private string lastTopic = null;
        private readonly Dictionary<string, string> userMemory = new Dictionary<string, string>();
        private Dictionary<string, KeywordHandler> keywordHandlers;
        private string currentMood = null;

        private delegate void KeywordHandler(string userInput);

        public CyberSecurityChatBot(string name) : base(name)
        {
            InitializeKeywordHandlers();
            LoadDictionaries();
        }

        private void LoadDictionaries()
        {
            try
            {
                if (File.Exists(KeywordResponsesFile))
                {
                    string json = File.ReadAllText(KeywordResponsesFile);
                    keywordResponses = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json) ?? keywordResponses;
                    Console.WriteLine("✅ Keyword responses loaded successfully.");
                }
                else
                {
                    Console.WriteLine("⚠️ Keyword responses file not found. Using default responses.");
                    SaveDictionaries();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"❌ Error loading keyword responses: {ex.Message}");
                Console.ResetColor();
            }
        }

        public void SaveDictionaries()
        {
            try
            {
                File.WriteAllText(KeywordResponsesFile, JsonConvert.SerializeObject(keywordResponses, Formatting.Indented));
                Console.WriteLine("💾 Keyword responses saved successfully.");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"❌ Error saving keyword responses: {ex.Message}");
                Console.ResetColor();
            }
        }

        public override void DisplayWelcomeMessage()
        {
            if (userMemory.ContainsKey("interest"))
            {
                Console.WriteLine($"👋 Welcome back, {UserName}! Last time, you were interested in {userMemory["interest"]}. Would you like to continue or explore something new?");
            }
            else
            {
                Console.WriteLine($"👋 Hello, {UserName}! Welcome aboard the CyberSecurity ChatBot! 🚀 How are you feeling about cybersecurity today?");
            }
        }

        protected override void HandleInitialSentiment(string feeling)
        {
            string mood = SentimentAnalyzer.AnalyzeMoodCategory(feeling);
            if (mood != "neutral")
            {
                currentMood = mood;
                switch (currentMood)
                {
                    case "worried":
                        Respond("😟 I understand you're feeling worried. Let's focus on practical steps to ease those concerns. Here are three fundamental tips:");
                        RespondWithPoints("basics");
                        break;
                    case "confused":
                        Respond("🤔 It's okay to feel confused about cybersecurity. My goal is to make it clearer for you. Let's start with three key aspects of a core topic. Which one would you like to begin with: Passwords, Scams, Privacy, or Phishing?");
                        break;
                    case "curious":
                        Respond("🧐 That's wonderful! A curious mind learns best. Let's explore that with three key points. Which topic are you most eager to explore: Passwords, Scams, Privacy, or Phishing?");
                        break;
                    case "frustrated":
                        Respond("😠 I'm sorry to hear you're feeling frustrated. Let's try to simplify things with three quick tips on a key area. How about we start with password safety?");
                        RespondWithPoints("password");
                        break;
                    case "sad":
                        Respond("😔 I'm sorry you're feeling sad. Let's focus on some actionable steps you can take to feel more secure online with three basic tips:");
                        RespondWithPoints("basics");
                        break;
                    case "happy":
                        Respond("😊 That's great to hear! Here are three important reminders to stay safe online:");
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

        private void InitializeKeywordHandlers()
        {
            keywordHandlers = new Dictionary<string, KeywordHandler>
            {
                { "password", HandleKeyword },
                { "scam", HandleKeyword },
                { "privacy", HandleKeyword },
                { "phishing", HandleKeyword }
            };
        }

        protected override void HandleTopics()
        {
            Console.WriteLine("Here are some key cybersecurity topics we can explore:");
            foreach (var currentTopic in keywordResponses.Keys)
            {
                Console.WriteLine($"- 💡 {currentTopic.ToUpper()}");
            }

            var interests = GetInterests();
            if (interests.Count > 0)
            {
                Console.WriteLine($"\nPreviously, you showed interest in: {string.Join(", ", interests.Select(i => i.ToUpper()))}.");
                Console.Write("Would you like to revisit one of these, or try a new topic? ");
            }
            else
            {
                Console.Write("\nWhich topic sparks your interest? Type it in! ");
            }

            string topic = Console.ReadLine()?.ToLower().Trim();

            if (!string.IsNullOrEmpty(topic) && keywordResponses.ContainsKey(topic))
            {
                lastTopic = topic;
                AddInterest(topic);
                RespondWithPoints(topic);
            }
            else
            {
                Console.WriteLine("🤔 Hmm, I don't seem to have specific information on that right now. Try one of the topics listed above!");
            }
            Console.WriteLine("Feel free to ask about another topic or let me know if you want more details on any of these!");
        }

        protected override void HandleSentiment(string userInput)
        {
            if (!string.IsNullOrEmpty(userInput))
            {
                var keyword = DetectKeyword(userInput);
                if (!string.IsNullOrEmpty(keyword))
                {
                    RespondWithPoints(keyword);
                    return;
                }

                string mood = SentimentAnalyzer.AnalyzeMoodCategory(userInput);
                if (mood != "neutral")
                {
                    currentMood = mood;
                    userMemory["lastMood"] = mood;
                }
                else if (IsFollowUpQuestion(userInput) && lastTopic != null)
                {
                    Respond($"Here's another helpful point about {lastTopic}: {GetRandomPoint(lastTopic)}");
                    Respond("Would you like to hear more, or is there another topic you're interested in?");
                    return;
                }
                else
                {
                    if (userMemory.ContainsKey("interest"))
                    {
                        Respond($"Previously, you asked about {userMemory["interest"]}. Would you like to continue on that, or explore something else?");
                    }
                    else
                    {
                        Respond("I'm not quite sure I understand. Could you try rephrasing or asking about passwords, scams, privacy, or phishing?");
                    }
                }
            }
            else
            {
                Respond("I didn't catch anything. Could you please type something?");
            }
        }

        private void HandleKeyword(string userInput)
        {
            string keyword = DetectKeyword(userInput);
            if (!string.IsNullOrEmpty(keyword))
            {
                RespondWithPoints(keyword);
            }
            else
            {
                Respond("That's an interesting point! However, I don't have specific information related to that right now.");
            }
        }

        private void RespondWithPoints(string keyword)
        {
            if (keywordResponses.ContainsKey(keyword))
            {
                var intros = new List<string>
                {
                    $"Here are some key things to know about {keyword.ToUpper()}:",
                    $"Let me share some important tips on {keyword.ToUpper()}:",
                    $"Consider these points about {keyword.ToUpper()}:",
                    $"Some essential advice for {keyword.ToUpper()}:",
                    $"What you should remember about {keyword.ToUpper()}:"
                };

                string intro = intros[random.Next(intros.Count)];
                Respond(intro);

                var points = keywordResponses[keyword].OrderBy(x => random.Next()).ToList();
                foreach (var point in points)
                {
                    Respond($"- {point}");
                }

                var followUps = new List<string>
                {
                    "Is there a particular point you'd like to know more about?",
                    "Would you like tips on another topic?",
                    "Do you have any questions about this?",
                    "Let me know if you want to dive deeper into any of these!",
                    "What else are you curious about in cybersecurity?"
                };
                Respond(followUps[random.Next(followUps.Count)]);
            }
            else
            {
                Respond($"Sorry, I don't have specific details on {keyword} right now.");
            }
        }

        private string GetRandomPoint(string keyword)
        {
            if (keywordResponses.ContainsKey(keyword))
            {
                var points = keywordResponses[keyword];
                int index = random.Next(points.Count);
                return points[index];
            }
            return "Sorry, I don't have more specific details on that.";
        }

        private string DetectKeyword(string userInput)
        {
            foreach (var keyword in keywordResponses.Keys)
            {
                if (userInput.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    userInput.IndexOf(keyword + "s", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    lastTopic = keyword;
                    AddInterest(keyword);
                    return keyword;
                }
            }
            return null;
        }

        private bool IsFollowUpQuestion(string userInput)
        {
            string[] followUpPhrases = { "can you explain", "what else", "how does that work", "give me another", "continue", "go on", "tell me more about", "why is that", "what if" };
            foreach (var phrase in followUpPhrases)
            {
                if (userInput.IndexOf(phrase, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        protected internal void AddInterest(string topic)
        {
            userMemory["interest"] = topic;
            if (userMemory.ContainsKey("interests"))
            {
                var interests = userMemory["interests"].Split(',').ToList();
                if (!interests.Contains(topic))
                {
                    interests.Add(topic);
                    userMemory["interests"] = string.Join(",", interests);
                }
            }
            else
            {
                userMemory["interests"] = topic;
            }
        }

        private List<string> GetInterests()
        {
            if (userMemory.ContainsKey("interests"))
                return userMemory["interests"].Split(',').ToList();
            return new List<string>();
        }
    }
}
