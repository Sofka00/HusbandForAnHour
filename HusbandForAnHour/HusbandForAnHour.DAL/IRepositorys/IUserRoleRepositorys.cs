﻿using HusbandForAnHour.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusbandForAnHour.DAL.IRepositorys
{
    internal interface IUserRoleRepositorys
    {
        public List<UserRoleDto> GetAllUserRole();
    }
}