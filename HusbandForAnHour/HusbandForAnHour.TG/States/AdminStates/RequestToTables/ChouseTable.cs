using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace HusbandForAnHour.TG.States.AdminStates.RequestToTables
{
    internal class ChouseTable : AbstractState
    {
        public override AbstractState ReceiveMessage(Update update)
        {
            AbstractState result = this;
            switch (update.CallbackQuery.Data)
            {
                case "Request":

                    break;
                 case "Service":

                    break;
                 case "Specialization":

                    break;
                 case "Status":

                    break;
                 case "User":

                    break;
                 case "UserRole":

                    break;

                default:
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
                            new InlineKeyboardButton("Заявки") { CallbackData="Request"},
                            new InlineKeyboardButton("Услуги") { CallbackData="Service"},
                        },
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Направление") { CallbackData="Specialization"},
                            new InlineKeyboardButton("Статусы") { CallbackData="Status"},
                        },
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Пользователи") { CallbackData="User"},
                            new InlineKeyboardButton("Роли") { CallbackData="UserRole"},
                        }
                              }
                              );

            SingleToneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Выбор таблицы", replyMarkup: markup);
        }
    }
}
