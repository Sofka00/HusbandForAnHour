using HusbandForAnHour.TG.States.AdminStates.RequestToTables.EditTable;
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
                    result = new EditRequestState();
                    break;
                 case "Service":
                    result = new EditServiceState();
                    break;
                 case "Specialization":
                    result = new EditSpecializationState();
                    break;
                 case "Status":
                     result=new EditStatusState();
                    break;
                 case "User":
                    result = new EditUserState();
                    break;
                 case "UserRole":
                    result = new EditUserRoleState();

                    break;

                default:
                    SingleToneStorage.GetStorage().Client.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Выбор Действия");

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
