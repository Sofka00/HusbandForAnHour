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
            if (update.CallbackQuery.Data == "1")
            {
                replyState=new ChouseTable();
            }
            else if (update.CallbackQuery.Data == "2")
            {
               
                replyState = new RequestProcessingState();
            }
            else if (update.CallbackQuery.Data == "3")
            {
                replyState = new CreateWorkerState();
            }                     
            else if (update.CallbackQuery.Data == "4")
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
                            new InlineKeyboardButton("Работа с таблицами") { CallbackData="1"},
                            new InlineKeyboardButton("Обработать Заявки") { CallbackData="2"},
                        },
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Заявки В работе") { CallbackData="3"},
                            new InlineKeyboardButton("Редактировать заявку") { CallbackData="4"},
                        }
                  }
                  );

            SingleToneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Выберите действие", replyMarkup: markup);
        }
    }
}
