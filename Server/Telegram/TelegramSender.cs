using OpenQA.Selenium.DevTools.V129.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Server.Telegram
{
    public class TelegramSender
    {
        private string BotToken;
        public TelegramSender(string BotToken)
        {
            this.BotToken = BotToken;
        }
        public async Task Send(long userID, string message)
        {
            var botClient = new TelegramBotClient(BotToken);
            try
            {
                await botClient.SendMessage(
                    chatId: userID,
                    text: message
                );
                Console.WriteLine("Сообщение успешно отправлено.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при отправке: {ex.Message}");
                Console.WriteLine($"Трассировка: {ex.StackTrace}");
            }
        }
    }
}
