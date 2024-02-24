﻿using HusbandForAnHour.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusbandForAnHour.BLL.Models.OutputModels
{
    public class SpecializationOutputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserDto> User { get; set; }
    }
}
