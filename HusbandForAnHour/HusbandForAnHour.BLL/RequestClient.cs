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
        public List<GetAllRequestOutPutModel> GetRequests()
        {
            List<GetAllRequestDto> requestDtos = _requestRepositiry.GetAllRequest();
            return _mapper.Map<List<GetAllRequestOutPutModel>>(requestDtos);


        }
        public List<GetAllRequestOutPutModel> GeAlltRequestsByWorker(long workerId)
        {
            List<GeAlltRequestsByWorkerDto> requestDtos = _requestRepositiry.GetRequestByWorker(workerId);
            return _mapper.Map<List<GetAllRequestOutPutModel>>(requestDtos);
        }

        public List<GeAlltRequestsByWorkerOutput> GeAlltRequestsByWorkerWithStatus(long workerId, int statusId)
        {
            List<GeAlltRequestsByWorkerDto> requestDtos = _requestRepositiry.GetRequestByWorker(workerId);
            List<GeAlltRequestsByWorkerDto> newList = new List<GeAlltRequestsByWorkerDto>();
            foreach (GeAlltRequestsByWorkerDto requestDto in requestDtos)
            {
                if (requestDto.StatusId == statusId)
                    newList.Add(requestDto);
            }


            return _mapper.Map<List<GeAlltRequestsByWorkerOutput>>(newList);
        }


    }
}