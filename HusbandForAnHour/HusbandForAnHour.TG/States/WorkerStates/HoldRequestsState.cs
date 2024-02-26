using HusbandForAnHour.BLL;
using HusbandForAnHour.BLL.Models.OutputModels;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace HusbandForAnHour.TG.States.WorkerStates
{
    public class HoldRequestsState : AbstractState
    {
        private RequestService _requestClient;
        private int clientId=0;
        public HoldRequestsState()
        {
            _requestClient = new RequestService();
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            AbstractState result = this;
            if (int.TryParse(update.Message.Text, out int id))
            {
                _requestClient.AcceptingRequest(id);
            }
            else
            {
                SingleToneStorage.GetStorage().Client.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Id Не выбран");

            }
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
            var c = _requestClient.GetAllRequestByWorkerByStatus(chatId, 1);
            string tmp = "";
            foreach (var requestsByWorker in c)
            {
                tmp += $"{requestsByWorker.Id},{requestsByWorker.Comment}, {requestsByWorker.Address},{requestsByWorker.Client.Phone}{Environment.NewLine}";

            }
            SingleToneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Все услуги которые ожидают принятия(введите id чтобы его принять):{Environment.NewLine}" + tmp);
        }
    }
}
