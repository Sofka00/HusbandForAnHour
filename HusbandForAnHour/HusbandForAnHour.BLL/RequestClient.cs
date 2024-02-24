using AutoMapper;
using HusbandForAnHour.BLL.Mapping;
using HusbandForAnHour.BLL.Models.OutputModels;
using HusbandForAnHour.DAL;
using HusbandForAnHour.DAL.Dtos;

namespace HusbandForAnHour.BLL
{
    public class RequestClient
    {
        private RequestRepository _requestRepositiry;
        private Mapper _mapper;

        public RequestClient()
        {
            _requestRepositiry = new RequestRepository();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new RequestMappingProfile());
            });
            _mapper = new Mapper(config);
        }
        public List<RequestOurputModel> GetRequests()
        {
            List<RequestDto> requestDtos = _requestRepositiry.GetAllRequest();
            return _mapper.Map<List<RequestOurputModel>>(requestDtos);


        }


    }
}