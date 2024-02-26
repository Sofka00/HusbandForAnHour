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
    public class EditRequestState : AbstractState
    {
        public override AbstractState ReceiveMessage(Update update)
        {
            AbstractState result = this;
            switch (update.CallbackQuery.Data)
            {
                case "1":

                    break;
                case "2":

                    break;
                case "3":

                    break;
                case "4":

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
                                    new InlineKeyboardButton("Изменить") { CallbackData="2"},
                                },
                                new InlineKeyboardButton[]
                                {
                                    new InlineKeyboardButton("Удалить") { CallbackData="3"},
                                    new InlineKeyboardButton("Восстановить") { CallbackData="4"},
                                }
                             }
                             );
            SingleToneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Выбор Действия", replyMarkup: markup);

        }
    }
}
