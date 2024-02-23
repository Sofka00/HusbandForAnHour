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
           
            return new BState("sss");
        }
        public override void SendMessage(long chatId)
        {
            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(
                    new InlineKeyboardButton[][]
                    {
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("111") { CallbackData="один"},
                            new InlineKeyboardButton("222") { CallbackData="два"},
                        },
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("333") { CallbackData="три"},
                        }
                    }
                    );

            SingleToneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Knopochki!!!", replyMarkup: markup);
        }
      



    }
}
