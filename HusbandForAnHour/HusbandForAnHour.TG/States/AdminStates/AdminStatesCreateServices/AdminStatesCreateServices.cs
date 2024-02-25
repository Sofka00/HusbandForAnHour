using HusbandForAnHour.BLL.Models.OutputModels;
using HusbandForAnHour.BLL;
using HusbandForAnHour.TG.States.AdminStates;
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
    public class AdminStatesCreateServices : AbstractState
    {
        private string _name;
        private SpecializationClient _specialization;

        public AdminStatesCreateServices(string name)
        {
            _name = name;
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            return new CreateNameState();
        }

        public override void SendMessage(long chatId)
        {
            _specialization = new SpecializationClient();
            List<GetAllSpecializationOutputModel> specializations = _specialization.GetSpecializations();
            List<List<InlineKeyboardButton>> keys = new List<List<InlineKeyboardButton>>();
            int count = 0;
            foreach (var specialization in specializations)
            {
                if (count % 2 == 0)
                {
                    keys.Add(new List<InlineKeyboardButton>());
                }
                keys[keys.Count - 1].Add(new InlineKeyboardButton(specialization.Name) { CallbackData = specialization.Name });
                count++;

            }

            SingleToneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Выберите специализацию", replyMarkup: new InlineKeyboardMarkup(keys)); ;
        }
    }
}
