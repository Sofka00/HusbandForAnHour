using HusbandForAnHour.TG.States.AdminStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using HusbandForAnHour.TG.States.AdminStates;
using HusbandForAnHour.TG.States.AdminStates.AdminCreateWorkerStates;


namespace HusbandForAnHour.TG.States.AdminStates
{
    public class AdminState : AbstractState
    {
        public override AbstractState ReceiveMessage(Update update)
        {   
            AbstractState replyState=new StartState();
            if (update.CallbackQuery.Data == "3")
            {
                replyState=new AdminStateRequest();
            }
            else if (update.CallbackQuery.Data == "1")
            {
               
                replyState = new CreateNameState();
            }
            else if (update.CallbackQuery.Data == "2")
            {
                replyState = new CreateWorkerState();
            }
                return replyState;
        }

        public override void SendMessage(long chatId)
        {
            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(
                  new InlineKeyboardButton[][]
                  {
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Добавить услугу") { CallbackData="1"},
                            new InlineKeyboardButton("Добавить мастера") { CallbackData="2"},
                        },
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Заявки") { CallbackData="3"},
                        }
                  }
                  );

            SingleToneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Выберите действие", replyMarkup: markup);
        }
    }
}
