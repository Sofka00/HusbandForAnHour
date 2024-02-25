using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HusbandForAnHour.DAL.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public  long? Phone { get; set; }
        public List<SpecializationDto> SpecializationId { get; set; }
        public bool IsDeleted { get; set; }
        public List<RequestDto> Requests { get; set; }  
    }
}
