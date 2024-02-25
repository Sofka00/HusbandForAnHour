using AutoMapper;
using HusbandForAnHour.BLL.Models.InputModels;
using HusbandForAnHour.BLL.Models.OutputModels;
using HusbandForAnHour.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusbandForAnHour.BLL.Mapping
{
    public class UserMappingProfile :Profile
    {
         public UserMappingProfile() 
        {
            CreateMap<UserDto, UserOutputModel>();
            CreateMap<UserInputModel, UserDto>();
            CreateMap<CreateWorkerInputModel, UserDto>();
        }
    }
}
