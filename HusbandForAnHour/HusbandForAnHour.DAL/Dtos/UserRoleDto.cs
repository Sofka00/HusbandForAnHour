using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusbandForAnHour.DAL.Dtos
{
    public class UserRoleDto
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
