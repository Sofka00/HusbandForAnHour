using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusbandForAnHour.TG.States.AdminStates
{
    public class RequestProcessingState:AbstractState
    { 
        private RequestService _requestService;
        public RequestProcessingState()
        {
            _requestService = new();
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            AbstractState result = this;
            var tmp = update.Message.Text.Split(" ");
            if (tmp.Length > 1 && tmp.Length < 3)
            {
                _requestService.CreateRequest(update.Message.Chat.Id, DateTime.Now, tmp[0], tmp[1]);
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
            var c = _requestService.GetAllRequestByStatus();
                SingleToneStorage.GetStorage().Client.SendTextMessageAsync(chatId, 
    }
}
