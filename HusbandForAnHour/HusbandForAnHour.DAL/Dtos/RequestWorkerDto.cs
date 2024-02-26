using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusbandForAnHour.DAL.Dtos
{
    public class RequestWorkerDto
    {
        public int IdRequest { get; set; }
        public long IdWorker { get; set; }
    }
}
