using HusbandForAnHour.TG.States.UserStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace HusbandForAnHour.TG.States.StartStates
{
    internal class LoginState : AbstractState
    {
        public override AbstractState ReceiveMessage(Update update)
        {   
            var result=new LoginState();
            switch (update.CallbackQuery.Data)
            {
                case "1":
                    return new UserStartState();
                    break;
                case "2":
                    break;
                default:
                    SingleToneStorage.GetStorage().Client.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Выберите действие кем вам войти");
                    
                    break;
            }
            return result;
        }

        public override void SendMessage(long chatId)
        {
            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(
                                new InlineKeyboardButton[][]
                                {
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Войти как пользователь") { CallbackData="1"},
                            new InlineKeyboardButton("Войти как исполнитель") { CallbackData="2"},
                        }
                                }
                                );

            SingleToneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Выберите действие", replyMarkup: markup);
        }
    }
}
