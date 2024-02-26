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
    public class AddServiceState : AbstractState
    {
        private ServiceService _serviceService;

        public AddServiceState()
        {
            _serviceService = new ServiceService();
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            AbstractState result = this;
            var tmp = update.Message.Text.Split(" ");
            if (tmp.Length == 2 && int.TryParse(tmp[1],out int specId))
            {

                _serviceService.CreateService(tmp[0], specId);
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
            SingleToneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Чтобы добавить услугу, введите данные через пробел: название, специализацию");
        }
    }
}
