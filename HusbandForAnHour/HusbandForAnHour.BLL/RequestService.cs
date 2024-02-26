using AutoMapper;
using HusbandForAnHour.BLL.Mapping;
using HusbandForAnHour.BLL.Models.OutputModels;
using HusbandForAnHour.DAL;
using HusbandForAnHour.DAL.Dtos;
using System.Collections.Generic;
using System.Net;

namespace HusbandForAnHour.BLL
{
    public class RequestService
    {
        private RequestRepository _requestRepository;
        private RequestWorkerRepository _requestWorkerRepository;
        private RequestServiceRepository _requestServiceRepository;
        private ServiceService _servicesClient;
        private UserService _userService;
        private StatusService _statusService;
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
            _statusService = new StatusService();
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
          public List<RequestOutputModel> GetAllRequestByWorkerByStatus(long id, int statusId)
        {
            var workers = _requestWorkerRepository.SelectRequestWorkerByWorker(id);
            var status= _statusService.GetStatus(statusId);
            List<RequestOutputModel> result = new();
            foreach (var item in workers)
            {
               var v= GetRequest(item.IdRequest);
                if (v.Status==status.Name)
                {
                    result.Add(v);
                }
            }
            return result;
        }

        public void CreateRequest(long clientId, DateTime date,string address, string comment)
        {
            _requestRepository.CreateRequest(clientId, date, address, 0, comment);
        }
         public void AcceptingRequest(int requestId)
        {
            _requestRepository.AcceptingRequest(requestId);
        }

        public int DeleteRequest(int id)
        {
            return _requestRepository.DeleteRequest(id);
        }

        public int RestoreRequest(int id)
        {
            return _requestRepository.RestoreRequest(id);
        }

        public int UpdateRequest(int id, long clientId, string comment, string address, DateTime? date=null,  int? statusId = null)
        {
            var tmp=_requestRepository.GetRequest(id);
            if (comment!=default)
            {
                tmp.Comment = comment;
            }

            if (date!=null)
            {
                tmp.Date =date.Value;
            }

            if (address!=default)
            {
                tmp.Address=address;
            }

            if (statusId != default)
            {
                tmp.StatusId= statusId!.Value;
            }
            return _requestRepository.UpdateRequest(id, clientId, tmp.Date, tmp.Address, tmp.StatusId, tmp.Comment);
        }
          

    }
}