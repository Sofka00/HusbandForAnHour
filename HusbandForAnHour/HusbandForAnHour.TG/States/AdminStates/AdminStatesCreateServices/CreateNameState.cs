using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace HusbandForAnHour.TG.States.AdminStates
{
    public class CreateNameState : AbstractState
    {
        public override AbstractState ReceiveMessage(Update update)
        {  
            if (update.Message.Text == default)
            { 
                SingleToneStorage.GetStorage().Client.SendTextMessageAsync(update.Message.Chat.Id, "Название услуги не может быть пустым");
                return this;
            }    


            return new AdminStatesCreateServices(update.Message.Text);
        }

        public override void SendMessage(long chatId)
        {
            SingleToneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Введите название услуги ");
        }
    }
}
