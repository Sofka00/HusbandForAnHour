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
        private string _name;
        public BState(string name)
        { 
            this._name = name; 
        }
        public override AbstractState ReceiveMessage(Update update)
        {
            return new ServicesState();
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

            SingleToneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "ппп", replyMarkup: markup);

            
        }

    }
}
