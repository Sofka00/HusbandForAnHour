using HusbandForAnHour.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusbandForAnHour.BLL.Models.OutputModels
{
    public class UserOutputModel
    {
        public long Id { get; set; }
        public UserRoleOutputModel Role { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public List<SpecializationOutputModel> specializations { get; set; }
    }
}
