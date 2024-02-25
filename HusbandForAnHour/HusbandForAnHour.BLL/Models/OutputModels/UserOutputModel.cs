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
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public long? Phone { get; set; }
        public int SpecializationId { get; set; }
        public bool IsDeleted { get; set; }
        public List<RequestOutputModel> Requests { get; set; }
    }
}
