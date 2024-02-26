using HusbandForAnHour.BLL;
using HusbandForAnHour.BLL.Models.OutputModels;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace HusbandForAnHour.TG.States.WorkerStates
{
    public class AcceptedRequestsState : AbstractState
    {
        private RequestService _requestClient;

        public AcceptedRequestsState()
        {
            _requestClient = new RequestService();
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            AbstractState result = new AcceptedRequestsState();
            switch (update.CallbackQuery.Data)
            {
                case "1":
                    result = new WorkerStartState();
                    break;
                default:
                    SingleToneStorage.GetStorage().Client.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Выберите действие вернуться в меню");
                    break;

            }
            return result;
        }

        public override void SendMessage(long chatId)
        {
            InlineKeyboardMarkup markup = new InlineKeyboardMarkup
                            (new InlineKeyboardButton[][]
                                {
                                    new InlineKeyboardButton[]
                                    {
                                        new InlineKeyboardButton("Вернутся к меню выбора") { CallbackData="1"},
                                    }

                                }
                            );
            //var c =_requestClient.GetAlltRequestsByWorkerWithStatus(chatId, 8);
            string tmp = "";
            //foreach (GeAlltRequestsByWorkerOutput requestsByWorker in c ) 
            //{
            //    tmp += $"{requestsByWorker}{Environment.NewLine}";

            //}
            SingleToneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Все услуги которые приняли:{Environment.NewLine}" + tmp, replyMarkup: markup);
        }
    }
}
