﻿using HusbandForAnHour.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusbandForAnHour.BLL.Models.InputModels
{
    public class SpecializationInputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserDto> User { get; set; }
    }
}