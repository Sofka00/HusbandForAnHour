using HusbandForAnHour.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace HusbandForAnHour.TG.States.AdminStates.RequestToTables.EditTable
{
    public class AddRequestState : AbstractState
    {
        private RequestService _requestService;

        public AddRequestState()
        {
            _requestService = new RequestService();
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            AbstractState result = this;
            var tmp = update.Message.Text.Split(" ");
            if (tmp.Length>1&& tmp.Length<3)
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
            SingleToneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Добавить заявку, вводите данные через пробел аддресс, комментарий");
        }
    }
}
