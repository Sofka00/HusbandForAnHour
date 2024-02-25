using HusbandForAnHour.BLL;
using HusbandForAnHour.BLL.Models.InputModels;
using HusbandForAnHour.BLL.Models.OutputModels;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace HusbandForAnHour.TG.States.AdminStates
{
    public class AdminStatesCreateServices : AbstractState
    {
        private string _name;
        private ServicesClient _servicesClient;
        private SpecializationClient _specialization;

        public AdminStatesCreateServices(string name)
        {
            _name = name;
            _specialization = new SpecializationClient();
            _servicesClient = new ServicesClient();
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            var lastId = _servicesClient.GetLastServiceId() + 1;
            int chooseSpec = int.Parse(update.CallbackQuery.Data);
            var tmp = new CreateServicesInputModel() { Id = lastId, Name = _name, SpecializationId = chooseSpec };
            _servicesClient.CreateServices(tmp);
            SingleToneStorage.GetStorage().Client.SendTextMessageAsync(update.CallbackQuery.From.Id, $"Услуга успешно добавлена {tmp.Id}, {tmp.Name}, {tmp.SpecializationId}");
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

            SingleToneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Выберите специализацию", replyMarkup: new InlineKeyboardMarkup(keys)); ;
        }
    }
}
