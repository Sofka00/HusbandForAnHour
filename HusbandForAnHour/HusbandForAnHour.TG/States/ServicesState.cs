using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace HusbandForAnHour.TG.States
{
    public class FState : AbstractState
    {
        public override AbstractState ReceiveMessage(Update update)
        {
            return this;
        }

        public override void SendMessage(long chatId)
        {
            for (int i=0; i<5; i++)
            {

            SingleToneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Pu pu");
            }
        }
    }
}
