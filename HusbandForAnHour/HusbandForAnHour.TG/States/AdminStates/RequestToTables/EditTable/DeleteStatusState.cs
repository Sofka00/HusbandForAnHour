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
    public class DeleteStatusState : AbstractState
    {
        private StatusService _statusService;
        public DeleteStatusState()
        {
            _statusService = new StatusService();
        }
        public override AbstractState ReceiveMessage(Update update)
        {
            AbstractState abstractState = this;
            if (int.TryParse(update.Message.Text, out int id))
            {
                _statusService.DeleteStatus(id);
            }
            else
            {
                SingleToneStorage.GetStorage().Client.SendTextMessageAsync(update.Message.Chat, "Id не вереен ");
                return this;
            }
            return new AdminState();
        }

        public override void SendMessage(long chatId)
        {
            SingleToneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Введите Id для удаления");
        }
    }
}
