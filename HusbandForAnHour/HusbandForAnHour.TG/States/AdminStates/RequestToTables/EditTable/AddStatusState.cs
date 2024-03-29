﻿using HusbandForAnHour.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace HusbandForAnHour.TG.States.AdminStates.RequestToTables.EditTable
{
    internal class AddStatusState : AbstractState
    {
        private StatusService _statusService;

        public AddStatusState()
        {
            _statusService = new StatusService();
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            AbstractState result = this;
            if (update.Message.Text != default)
            {
                _statusService.CreateStatus(update.Message.Text);
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
            SingleToneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Чтобы добавить статус, введите данные через пробел: название");
        }
    }
}
