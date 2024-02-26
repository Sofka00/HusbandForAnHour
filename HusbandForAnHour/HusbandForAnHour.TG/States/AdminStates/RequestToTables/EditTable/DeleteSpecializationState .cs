using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusbandForAnHour.TG.States.AdminStates.RequestToTables.EditTable
{
    internal class DeleteSpecializationState : AbstractState
    {
        private SpecializationService _specializationService;
        public DeleteSpecializationState()
        {
            _specializationService = new SpecializationService();
        }
        public override AbstractState ReceiveMessage(Update update)
        {
            AbstractState abstractState = this;
            if (int.TryParse(update.Message.Text, out int id))
            {
                _specializationService.DeleteSpecialization(id);
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
