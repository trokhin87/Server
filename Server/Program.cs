using Server;
using Server.Data;
using Server.DataBase;
using Server.Chat;
using Server.Telegram;

class Program
{
    static async Task Main()
    {
        DataReader data = new DataReader(@"Data\DataAppConfig.json");
        //DataQuery dataQuery=new DataQuery(data.ConnectToDb);
        //List<Friend> strings = dataQuery.Users();
        DataQuery dataQuery = new DataQuery(data.ConnectToDb);
        Chat chat = new Chat();
        List<Friend> friends = dataQuery.Users();
        var telega = new TelegramSender(data.Telegram);
        foreach (Friend friend in friends)
        {
            await telega.Send(friend.telegram_id,chat.ChatAnswer(friend.Promt()));
        }
        
        
    }
}