using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace HusbandForAnHour.TG.States.ClientStates
{
    internal class ClientState : AbstractState
    {
        public override AbstractState ReceiveMessage(Update update)
        {
            throw new NotImplementedException();
        }

        public override void SendMessage(long chatId)
        {
            throw new NotImplementedException();
        }
    }
}
