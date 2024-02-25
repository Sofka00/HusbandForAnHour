using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace HusbandForAnHour.TG.States.AdminStates.AdminCreateWorkerStates
{
    public class CreateWorkerState : AbstractState
    {
        public override AbstractState ReceiveMessage(Update update)
        {
            var c = update.Message.Text.Split(" ");

            if (c.Length!=3 || c[2].Length!=11 ||!long.TryParse(c[2], out long result))
            {
                SingleToneStorage.GetStorage().Client.SendTextMessageAsync(update.Message.Chat.Id, "Неверный формат ввода");
                return this;

            }
            return new CreateSpecIdState(c[0], c[1], result);
        }

        public override void SendMessage(long chatId)
        {
            SingleToneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Введите Имя, Фамилию и номер телефона (только цифры) через пробел");
        }
    }
}
