using HusbandForAnHour.BLL;
using HusbandForAnHour.BLL.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace HusbandForAnHour.TG.States
{ 
    public class ServicesState : AbstractState
    {
        private ServiceService _services;
      

        public override AbstractState ReceiveMessage(Update update)
        {
            return this;
        }

        public override void SendMessage(long chatId)
        {
            _services = new ServiceService();
           List<ServicesOutputModel> services = _services.GetServices();
           List<List<InlineKeyboardButton>> keys = new List<List<InlineKeyboardButton>>();
            int count = 0;
            foreach (var service in services)
            {
                if (count%2 == 0) 
                {
                    keys.Add (new List<InlineKeyboardButton>());
                }
                keys[keys.Count - 1].Add(new InlineKeyboardButton(service.Name) { CallbackData=service.Name});
                count++;

            }
                    SingleToneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Выберите услугу", replyMarkup: new InlineKeyboardMarkup(keys));
        }
    }
}
