using HusbandForAnHour.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusbandForAnHour.BLL.Models.InpetModels
{
    internal class RequestInputModel
    {
        public int ClientId { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public string? Comment { get; set; }
    }
}
