

using Server;
using Server.Data;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("eqf");
        DataReader data = new DataReader(@"C:\Users\trokh\source\repos\Server\Server\Data\Data.json");
        //DataQuery dataQuery=new DataQuery(data.ConnectToDb);
        //List<Friend> strings = dataQuery.Users();
        var telega=new TelegramSender(data.Telegram);
        await telega.Send(728782230, "поцелуй меня в попу");
        
        //foreach (var n in strings)
        //{
        //    Console.WriteLine(n.ToString());
        //}
    }
}