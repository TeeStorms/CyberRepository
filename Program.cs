using System;
using CyberAwarenessBot;

class Program
{
    static void Main(string[] args)
    {
        ConsoleUI.AskUserName(out string userName);
        CyberSecurityChatBot bot = new CyberSecurityChatBot(userName);

        bot.StartChat();

        // Save dictionaries before exiting
        bot.SaveDictionaries();
    }
}

