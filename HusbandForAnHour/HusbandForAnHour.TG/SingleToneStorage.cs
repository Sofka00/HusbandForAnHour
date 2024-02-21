using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using HusbandForAnHour.TG.States;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

namespace HusbandForAnHour.TG
{
    public class SingleToneStorage
    {
        private static SingleToneStorage _object = null; // приватное статическое поле равное нал, если оно = нал, то в эту переменную кладем новый объект, а так всегда возвращаем этот объект
        public ITelegramBotClient Client { get; private set; }
        public Dictionary<long, AbstractState> Clients {get; private set;}
        private SingleToneStorage() 
        {
            Client = new TelegramBotClient("6337991749:AAEjdp96KjrEMbUvimVSd3gGqrfuB7H68c8");
            Clients = new Dictionary<long, AbstractState>();
        }
        public static SingleToneStorage GetStorage() 
        {
             if (_object is  null) 
            { 
                _object = new SingleToneStorage();
            }


            return _object;
        }
       

    }
}
