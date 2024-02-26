using HusbandForAnHour.BLL;
using HusbandForAnHour.TG.States.WorkerStates;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace HusbandForAnHour.TG.States
{
    public class WorkerStartState : AbstractState
    {
        private RequestService _requestService;
        public WorkerStartState()
        {
            _requestService = new();
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            AbstractState result = new WorkerStartState();
            switch (update.CallbackQuery.Data)
            {
                case "1":
                    result = new AcceptedRequestsState();
                    break;                          
                case "2":
                    result = new CompleatedRequestsState();

                    break;
                case "3":
                    result = new HoldRequestsState();
                    break;
                case "4":
                    
                    break;
                default:
                    SingleToneStorage.GetStorage().Client.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Выберите действие что хотите посмотреть");
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
                                        new InlineKeyboardButton("Принятые заявки") { CallbackData="1"},
                                        new InlineKeyboardButton("Выполненые заявки") { CallbackData="2"},
                                    },
                                    new InlineKeyboardButton[]
                                    {
                                        new InlineKeyboardButton("Подтвердить заявки") { CallbackData="3"},
                                        new InlineKeyboardButton("Посмотреть конкретную заявку") { CallbackData="4"},

                                    }

                                            }
                             );

            SingleToneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Выберите действие", replyMarkup: markup);
        }
    }
}
