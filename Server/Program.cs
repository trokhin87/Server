using Server;
using Server.Data;
using Server.DataBase;
using Server.Telegram;

class Program
{
    static async Task Main()
    {
        DataReader data = new DataReader(@"Data\DataAppConfig.json");
        //DataQuery dataQuery=new DataQuery(data.ConnectToDb);
        //List<Friend> strings = dataQuery.Users();
        DataQuery dataQuery=new DataQuery(data.ConnectToDb);
        var telega=new TelegramSender(data.Telegram);
        await telega.Send(728782230, "поцелуй меня в попу");
        
        
    }
}