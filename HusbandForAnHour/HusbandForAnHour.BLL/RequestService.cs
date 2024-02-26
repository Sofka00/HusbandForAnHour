using AutoMapper;
using HusbandForAnHour.BLL.Mapping;
using HusbandForAnHour.BLL.Models.OutputModels;
using HusbandForAnHour.DAL;
using HusbandForAnHour.DAL.Dtos;

namespace HusbandForAnHour.BLL
{
    public class RequestService
    {
        private RequestRepository _requestRepository;
        private RequestWorkerRepository _requestWorkerRepository;
        private RequestServiceRepository _requestServiceRepository;
        private ServicesService _servicesClient;
        private UserService _userService;
        private Mapper _mapper;

        public RequestService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ServicesMappingProfile());
            });
            _mapper = new Mapper(config);
            _userService = new UserService();
            _requestWorkerRepository = new RequestWorkerRepository();
            _requestRepository = new RequestRepository();

        }

        public RequestOutputModel GetRequest(int id)
        {
            var dto = _requestRepository.GetRequest(id);
            var result = _mapper.Map<RequestOutputModel>(dto);
            var workers=_requestWorkerRepository.SelectRequestWorkerByRequest(id);
            foreach (var worker in workers)
            {
                result.Workers.Add(_userService.GetUser(worker.IdWorker));
            }
            result.Client = _userService.GetUser(dto.ClientId);
            var serDto = _requestServiceRepository.GetRequestServiceByRequest(id);
            foreach(var ser in serDto)
            {
                result.Services.Add(_servicesClient.GetService(ser.IdService));
            }
            return result;
        }

        public List<RequestOutputModel> GetRequestByClient(long clientId)
        {
            var dtos = _requestRepository.GetRequestByClient(clientId);
            return _mapper.Map<List<RequestOutputModel>>(dtos);
        }

        public void CreateRequest(RequestDto requestDto)
        {
            _requestRepository.CreateRequest(requestDto.ClientId, requestDto.Date, requestDto.Address, requestDto.StatusId, requestDto.Comment);
        }

        public int DeleteRequest(int id)
        {
            return _requestRepository.DeleteRequest(id);
        }

        public int RestoreRequest(int id)
        {
            return _requestRepository.RestoreRequest(id);
        }

        public int UpdateRequest(RequestDto requestDto)
        {
            return _requestRepository.UpdateRequest(requestDto.Id, requestDto.ClientId, requestDto.Date, requestDto.Address, requestDto.StatusId, requestDto.Comment);
        }


    }
}