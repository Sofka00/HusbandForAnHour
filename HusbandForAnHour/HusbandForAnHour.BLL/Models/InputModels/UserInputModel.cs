using HusbandForAnHour.BLL.Models.InpetModels;
using HusbandForAnHour.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusbandForAnHour.BLL.Models.InputModels
{
    public class UserInputModel
    {
        public int Id { get; set; }
        public UserRoleInputModel Role { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public List<ServicesInputModel> Specialization { get; set; }
        public List<RequestInputModel> Requests { get; set; }
    }
}
