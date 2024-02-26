using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusbandForAnHour.BLL.Models.OutputModels
{
    public class GetAllRequestOutPutModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public int? Phone { get; set; }
        public string Name { get; set; }
    }
}
