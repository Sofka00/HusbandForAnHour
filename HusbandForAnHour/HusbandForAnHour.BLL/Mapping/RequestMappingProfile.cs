using AutoMapper;
using HusbandForAnHour.BLL.Models.InpetModels;
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
    public class RequestMappingProfile: Profile
    {
        public RequestMappingProfile()
        {
            CreateMap <RequestInputModel, RequestDto> ();
            CreateMap <RequestDto, RequestOutputModel> ();
            CreateMap<UserDto, RequestOutputModel>();
            CreateMap<RequestInputModel, UserDto> ();
            CreateMap<GetAllRequestDto,GetAllRequestOutPutModel> ();
            CreateMap<GeAlltRequestsByWorkerDto, GeAlltRequestsByWorkerOutput>();
           

        }
          
         
    }
}
