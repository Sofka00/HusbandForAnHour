using HusbandForAnHour.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusbandForAnHour.BLL.Models.InputModels
{
    public class CreateWorkerInputModel
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int SpecializationId { get; set; }
        public long? Phone { get; set; }
      
       
      
    }
}
