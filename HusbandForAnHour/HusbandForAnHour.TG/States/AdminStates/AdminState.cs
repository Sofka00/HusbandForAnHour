using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace HusbandForAnHour.TG.States.AdminStates
{
    public class AdminState : AbstractState
    {
        public override AbstractState ReceiveMessage(Update update)
        {
            return new AdminStateRequest();
        }

        public override void SendMessage(long chatId)
        {
            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(
                  new InlineKeyboardButton[][]
                  {
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Добавить услугу") { CallbackData="Усулууги"},
                            new InlineKeyboardButton("Добавить мастера") { CallbackData="два"},
                        },
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Заявки") { CallbackData="три"},
                        }
                  }
                  );

            SingleToneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Выберите действие", replyMarkup: markup);
        }
    }
}
