using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
namespace HusbandForAnHour.TG
{
    public class Program
    {
        static void Main(string[] args)
        {
            ITelegramBotClient client = new TelegramBotClient("6337991749:AAEjdp96KjrEMbUvimVSd3gGqrfuB7H68c8");
            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }, // receive all update types
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
            Console.WriteLine(update.Message.Text);
        }
        public static void HandleError(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {

        }
    }
}
