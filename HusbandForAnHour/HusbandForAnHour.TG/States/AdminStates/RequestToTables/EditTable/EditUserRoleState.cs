using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace HusbandForAnHour.TG.States.AdminStates.RequestToTables.EditTable
{
    public class EditUserRoleState : AbstractState
    {
        public override AbstractState ReceiveMessage(Update update)
        {
            AbstractState result = this;
            switch (update.CallbackQuery.Data)
            {
                case "1":
                    result = new AddUserRoleState();
                    break;
                case "2":
                    result = new DeleteUserRoleState();
                    break;
                 case "3":
                    result = new RestoreUserRoleState();
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
                                    new InlineKeyboardButton("Добавить") { CallbackData="1"},
                                    new InlineKeyboardButton("Удалить") { CallbackData="2"},
                                },
                                new InlineKeyboardButton[]
                                {
                                    new InlineKeyboardButton("Восстановить") { CallbackData="3"},
                                }
                             }
                             );
            SingleToneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Выбор Действия", replyMarkup: markup);

        }
    }
}
