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
    public class ServicesMappingProfile : Profile
    {
        public ServicesMappingProfile()
        {
            CreateMap<ServicesDto, ServicesOutputModel>();
            CreateMap<ServicesInputModel, ServicesDto>();
            CreateMap<CreateServicesInputModel, ServicesDto>();
        }
    }
}
