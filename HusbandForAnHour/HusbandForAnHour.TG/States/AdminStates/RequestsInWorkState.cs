using HusbandForAnHour.BLL;
using HusbandForAnHour.TG.States;
using HusbandForAnHour.TG.States.AdminStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace HusbandForAnHour.TG.State
{
    public class RequestsInWorkState : AbstractState
    {
        private RequestService _requestService;
        public RequestsInWorkState()
        {
            _requestService = new();
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            AbstractState result = this;
            if (int.TryParse(update.Message.Text, out int find))
            {
                result = new AdminState();
            }
            else
            {
                SingleToneStorage.GetStorage().Client.SendTextMessageAsync(update.Message.Chat.Id, "Ввод неверный");
            }
            return result;
        }

        public override void SendMessage(long chatId)
        {
            var allRequest = _requestService.GetAllRequestByStatus(1);
            string tmp = "";
            foreach (var item in allRequest)
            {
                string tmpserv = "";
                foreach (var xitem in item.Services)
                {
                    tmpserv += $"{xitem.Name} {Environment.NewLine}";
                }
                tmp += $"{item.Id}, {item.Date.ToShortDateString}, {item.Address}, {item.Comment},{item.Status},{tmpserv} {Environment.NewLine}";
            }
        }
    }
}
