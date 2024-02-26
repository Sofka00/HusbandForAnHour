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
    public class AddUserState : AbstractState
    {
        private UserService _userService;

        public AddUserState()
        {
            _userService = new UserService();
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            AbstractState result = this;
            var tmp = update.Message.Text.Split(" ");
            if (tmp.Length == 2 && int.TryParse(tmp[1], out int userId) && long.TryParse(tmp[2], out long userPhone))
            {

                _userService.CreateUser(userId, tmp[0], tmp[1], userPhone);
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
            SingleToneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Чтобы добавить пользователя, введите данные через пробел: имя, фамилию, номер телефона");
        }
    }
}
