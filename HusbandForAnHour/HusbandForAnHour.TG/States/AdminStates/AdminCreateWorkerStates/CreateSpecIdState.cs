using HusbandForAnHour.BLL.Models.InputModels;
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

namespace HusbandForAnHour.TG.States.AdminStates.AdminCreateWorkerStates
{
    public class CreateSpecIdState:AbstractState
    {
        private string _firstName;
        private string _secondName;
        private long _phone;
        private UserClient _userClient;
        private UserRoleClient _userRoleClient;
        private SpecializationClient _specialization;

        public CreateSpecIdState(string firstName, string secondName, long phone)
        {
            _firstName = firstName;
            _secondName = secondName;
            _phone = phone;
            _userClient = new UserClient();
            _userRoleClient = new UserRoleClient();
            _specialization = new SpecializationClient();
        }

        public override AbstractState ReceiveMessage(Update update)
        {
      
            var lastId = _userClient.GetLastUserId() + 1;
            int chooseSpec = int.Parse(update.CallbackQuery.Data);
            var tmp = new CreateWorkerInputModel() { Id = lastId, RoleId = 1, FirstName=_firstName, SecondName=_secondName, Phone=_phone, SpecializationId = chooseSpec };
            _userClient.CreateWorker(tmp);
            SingleToneStorage.GetStorage().Client.SendTextMessageAsync(update.CallbackQuery.From.Id, $"Мастер успешно добвлен {tmp.Id}, {tmp.RoleId}, {tmp.FirstName}, {tmp.SecondName}, {tmp.Phone} {tmp.SpecializationId}");
            return new AdminState();

        }

        public override void SendMessage(long chatId)
        {
            List<GetAllSpecializationOutputModel> specializations = _specialization.GetSpecializations();
            List<List<InlineKeyboardButton>> keys = new List<List<InlineKeyboardButton>>();
            int count = 0;
            foreach (var specialization in specializations)
            {
                if (count % 2 == 0)
                {
                    keys.Add(new List<InlineKeyboardButton>());
                }
                keys[keys.Count - 1].Add(new InlineKeyboardButton(specialization.Name) { CallbackData = specialization.Id.ToString() });
                count++;
            }

            SingleToneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Выберите специализацию", replyMarkup: new InlineKeyboardMarkup(keys));
        }
    }
}
