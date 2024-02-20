using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
namespace HusbandForAnHour.TG
{
    public class Program
    {
        static List<long> chats = new List<long>();
        static void Main(string[] args)
        {
            ITelegramBotClient client = new TelegramBotClient("6337991749:AAEjdp96KjrEMbUvimVSd3gGqrfuB7H68c8");
            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;

            var receiverOptions = new ReceiverOptions()
            {
                AllowedUpdates = [UpdateType.Message, UpdateType.CallbackQuery]
                //ThrowPendingUpdates = true
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
            if (update.Type == UpdateType.Message)
            {
                if (update.Message.Text == "/start")
                {
                    chats.Add(update.Message.Chat.Id);
                }
                //Console.WriteLine($" {update.Message.Chat.Id} {update.Message.Chat.FirstName} {update.Message.Chat.LastName}{update.Message.Text}");
                //foreach (var i in chats)
                //{
                //    if (i != update.Message.Chat.Id)
                //    {

                //        botClient.SendTextMessageAsync(i, "pupu");
                //    }
                //}
                InlineKeyboardMarkup markup = new InlineKeyboardMarkup (
                    new InlineKeyboardButton[][]
                    {
                            new InlineKeyboardButton[] 
                            {
                                new InlineKeyboardButton ("Услуги") {CallbackData = "список сервисов"},
                                new InlineKeyboardButton ("Заказать услугу") {CallbackData = "gegege"}
                            },
                            new InlineKeyboardButton[]
                            {
                                 new InlineKeyboardButton ("Статус") {CallbackData = "Статус"}
                            }
                    }
                    );
                botClient.SendTextMessageAsync(update.Message.Chat.Id, "knopki", replyMarkup: markup);
            }
            else if (update.Type == UpdateType.CallbackQuery)
            {
                Console.WriteLine(update.CallbackQuery.Data);
            }

        }
        public static void HandleError(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {

        }
    }
}
