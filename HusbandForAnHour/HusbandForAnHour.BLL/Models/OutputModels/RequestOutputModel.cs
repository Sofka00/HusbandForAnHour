﻿using HusbandForAnHour.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusbandForAnHour.BLL.Models.OutputModels
{
    public class RequestOutputModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public List<UserOutputModel> Workers { get; set; }
        public UserOutputModel Client { get; set; }
        public List<ServicesOutputModel> Services { get; set; }
    }
}
