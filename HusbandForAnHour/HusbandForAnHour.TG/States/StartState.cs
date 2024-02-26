using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace HusbandForAnHour.TG.States
{
    public class StartState : AbstractState
    {
        //public override AbstractState ReceiveMessage(Update update)
        //{  if (update.Type== UpdateType.Message)
        //    { var message = update.Message.Text;
        //        if (message.ToLower() == "f")
        //        {
        //            return new FState();
        //        }
        //        else if (message == "b")
        //        {
        //            return new BState(update.Message.Chat.Username);
        //        }
        //    }
        //        return this;
        //}
        public override AbstractState ReceiveMessage(Update update)
        {

            return new WorkerStartState();
        }
        public override void SendMessage(long chatId)
        {
            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(
                    new InlineKeyboardButton[][]
                    {
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Заказать услугу") { CallbackData="1"},
                            new InlineKeyboardButton("Услуги") { CallbackData="2"},
                        },
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Статус заказа") { CallbackData="3"},
                        }
                    }
                    );

            SingleToneStorage.GetStorage().Client.SendTextMessageAsync(chatId,"Выберите действие", replyMarkup: markup);
        }
      



    }
}
