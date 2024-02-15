using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HusbandForAnHour.DAL.Dtos
{
    public class RequestDto
    {
        public  int Id { get; set; }
        public List<UserDto> Worker { get; set; }
        public int ClientId { get; set; }
        public List<ServicesDto> Services { get; set; }
        public DateTime Date {  get; set; }
        public string Address { get; set; }
        public int StatusId { get; set; }
        public string? Comment { get; set; }


    }
}
