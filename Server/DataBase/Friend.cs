using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DataBase
{
    public class Friend
    {
        public long telegram_id { get; set; }
        public string? friend_username { get; set; }
        public string? interested { get; set; }
        public override string ToString()
        {
            return $"Telegram ID: {telegram_id}, Username: {friend_username}, Interested: {interested}";
        }
        public string Promt()
        {
            return $"Напиши поздравление с днем рождения для {friend_username},у которого в интересах:{interested}";
        }
    }
}
