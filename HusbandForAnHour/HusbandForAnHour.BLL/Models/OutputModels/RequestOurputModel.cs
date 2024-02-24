using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusbandForAnHour.BLL.Models.OutputModels
{
    public class RequestOurputModel
    {
        public int ClientId { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }

    }
}
