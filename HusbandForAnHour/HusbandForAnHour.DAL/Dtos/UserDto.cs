using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusbandForAnHour.DAL.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public int RolrId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public  int Phone { get; set; }
        public int SpecializationId { get; set; }
        public bool IsDeleted { get; set; }

    }
}
