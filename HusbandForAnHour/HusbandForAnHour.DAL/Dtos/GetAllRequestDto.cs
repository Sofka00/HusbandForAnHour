﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusbandForAnHour.DAL.Dtos
{
    public class GetAllRequestDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public DateTime Date { get; set; }
        public int StatusId { get; set; }
        public string Address { get; set; }
        public int? Phone { get; set; }

    }
}