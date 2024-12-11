using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Friend
    {
        public long? telegram_id { get; set; }
        public string? friend_username { get; set; }
        public string? interested { get; set; }
        public override string ToString()
        {
            return $"Telegram ID: {telegram_id}, Username: {friend_username}, Interested: {interested}";
        }
    }
}
