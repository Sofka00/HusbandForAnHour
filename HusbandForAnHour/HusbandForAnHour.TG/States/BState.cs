using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace HusbandForAnHour.TG.States
{
    public class BState : AbstractState
    {
        public string name;
        public BState(string name)
        { 
            this.name = name; 
        }
        public override AbstractState ReceiveMessage(Update update)
        {
            return new FState();
        }

        public override void SendMessage(long chatId)
        {
            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(
                    new InlineKeyboardButton[][]
                    {
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("huy") { CallbackData="один"},
                            new InlineKeyboardButton("yyy") { CallbackData="два"},
                        },
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("tt") { CallbackData="три"},
                        }
                    }
                    );

            SingleToneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Knopochki!!!", replyMarkup: markup);

            
        }

    }
}
