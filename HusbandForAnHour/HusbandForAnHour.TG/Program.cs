using HusbandForAnHour.TG.States;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
namespace HusbandForAnHour.TG
{
    public class Program
    {
        //static List<long> chats = new List<long>();
        private SingleToneStorage _storage;
        static void Main(string[] args)
        {

        ITelegramBotClient client = SingleToneStorage.GetStorage().Client;
        var cts = new CancellationTokenSource();
        var cancellationToken = cts.Token;

        var receiverOptions = new ReceiverOptions()
        {
            AllowedUpdates = [UpdateType.Message, UpdateType.CallbackQuery], 
                ThrowPendingUpdates = true
        };

        client.StartReceiving
                (
                HandleUpdate,
                HandleError,
                receiverOptions,
                cancellationToken
                );
            string end = "";
            do
                end = Console.ReadLine();
            while (end != "end");

        }
    public static void HandleUpdate(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
         var users= SingleToneStorage.GetStorage().Clients;
            long id = update.Message.Chat.Id;
            if (!users.ContainsKey(id)) 
            {
                users.Add(id, new StartState());
                users[id].SendMessage(id);
            }
            else 
            {
                users[id]=users[id].ReceiveMessage(update);
            }
                users[id].SendMessage(id);

    }
    public static void HandleError(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {

    }
}
}
