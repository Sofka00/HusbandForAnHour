using AutoMapper;
using HusbandForAnHour.BLL.Mapping;
using HusbandForAnHour.BLL.Models.OutputModels;
using HusbandForAnHour.DAL;
using HusbandForAnHour.DAL.Dtos;
using System.Collections.Generic;

namespace HusbandForAnHour.BLL
{
    public class RequestService
    {
        private RequestRepository _requestRepository;
        private RequestWorkerRepository _requestWorkerRepository;
        private RequestServiceRepository _requestServiceRepository;
        private ServiceService _servicesClient;
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

        public List<RequestOutputModel> GetAllRequestByStatus(int statusId)
        {
            var dtos = _requestRepository.GetAllRequestByStatus(statusId);
            List<RequestOutputModel> result = new();
            foreach (var item in dtos)
            {
                result.Add(GetRequest(item.Id));
            }
            return result;
        }

        public void CreateRequest(long clientId, DateTime date,string address, string comment)
        {
            _requestRepository.CreateRequest(clientId, date, address, 0, comment);
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