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
    internal class UpdateServiceState : AbstractState
    {
        private ServiceService _requestService;
        public UpdateServiceState()
        {
            _requestService = new RequestService();

        }
        public override AbstractState ReceiveMessage(Update update)
        {
            AbstractState abstractState = this;

            var tmp = update.Message.Text.Split(" ");
            if (tmp.Length == 2 && int.TryParse(tmp[0], out int id) && long.TryParse(tmp[1], out long clientId) && DateTime.TryParse(tmp[4], out DateTime date) && int.TryParse(tmp[5], out int statusId))
            {
                _requestService.UpdateRequest(id, clientId, tmp[2], tmp[3], date, statusId);
            }
            else
            {
                SingleToneStorage.GetStorage().Client.SendTextMessageAsync(update.Message.Chat, "Id не вереен ");
            }
            return this;

            return new AdminState();
        }

        public override void SendMessage(long chatId)
        {
            var status = _statusService.GetAllStatus();
            SingleToneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Введите поля для обновления через проблел: ID запросы, коммент, адрес, дата, IDстатус");
            SingleToneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"{status}");
        }
    }
}
