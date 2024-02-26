using AutoMapper;
using HusbandForAnHour.BLL.Mapping;
using HusbandForAnHour.BLL.Models.OutputModels;
using HusbandForAnHour.DAL;
using HusbandForAnHour.DAL.Dtos;
using HusbandForAnHour.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HusbandForAnHour.BLL
{
    public class StatusService
    {
        private StatusRepository _repository;
        private Mapper _mapper;

        public StatusOutputModel GetStatus(int id)
        {
            var statusDto = _repository.GetStatus(id);
            var statusOutputModel = _mapper.Map<StatusOutputModel>(statusDto);
            return statusOutputModel;
        }

        public void CreateStatus(string name)
        {
            _repository.CreateStatus(name);
        }

        public int UpdateStatus(int id, string name)
        {
            return _repository.UpdateStatus(id, name);
        }

        public int DeleteStatus(int id)
        {
            return _repository.DeleteStatus(id);
        }

        public int RestoreStatus(int id)
        {
            return _repository.RestoreStatus(id);
        }
        public List<StatusDto> GetAllStatus()
        {
            return _repository.GetAllStatus();
        }
    }
}
