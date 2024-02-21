using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

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
            return new StartState();
        }

        public override void SendMessage(long chatId)
        {
            for (int i = 0; i < 5; i++)
            {

                SingleToneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"{name}");
            }
        }
    }
}
