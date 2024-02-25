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

namespace HusbandForAnHour.TG.States.AdminStates
{
    public class AdminStateRequest : AbstractState
    {
        private RequestClient _request;
        public override AbstractState ReceiveMessage(Update update)
        {
            return this;
        }

        public override void SendMessage(long chatId)
        {
            string message = "";
            _request = new RequestClient();
            List<GetAllRequestOutPutModel> requests = _request.GetRequests();
            foreach(GetAllRequestOutPutModel request in requests) 
            {
                message += $" {request.Id}{request.FirstName} {request.SecondName} {request.Date}  {request.Address} {request.Phone} {request.Status} {Environment.NewLine}";
            }
            SingleToneStorage.GetStorage().Client.SendTextMessageAsync(chatId,$"Заявки: {Environment.NewLine} " + message);


        }
    }
}
