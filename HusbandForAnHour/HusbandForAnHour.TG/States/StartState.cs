using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace HusbandForAnHour.TG.States
{
    public class StartState : AbstractState
    {
        public override AbstractState ReceiveMessage(Update update)
        {  if (update.Type== UpdateType.Message)
            { var message = update.Message.Text;
                if (message.ToLower() == "f")
                {
                    return new FState();
                }
                else if (message == "b")
                {
                    return new BState(update.Message.Chat.Username);
                }
            }
                return this;
        }

        public override void SendMessage(long chatId)
        {
            SingleToneStorage.GetStorage().Client.SendTextMessageAsync(chatId,"Privet f or b");
        }

      
    }
}
