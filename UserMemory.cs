using System.Collections.Generic;

namespace CyberAwarenessBot
{
    public class UserMemory
    {
        public string UserName { get; set; }
        public string FavoriteTopic { get; set; }

        public void Remember(string key, string value)
        {
            if (key.ToLower() == "name")
            {
                UserName = value;
            }
            else if (key.ToLower() == "topic")
            {
                FavoriteTopic = value;
            }
        }

        public string Recall(string key)
        {
            if (key.ToLower() == "name")
            {
                return UserName;
            }
            else if (key.ToLower() == "topic")
            {
                return FavoriteTopic;
            }

            return null;
        }
    }
}
