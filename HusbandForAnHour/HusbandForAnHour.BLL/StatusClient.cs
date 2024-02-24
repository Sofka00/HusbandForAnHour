using AutoMapper;
using HusbandForAnHour.BLL.Mapping;
using HusbandForAnHour.BLL.Models.OutputModels;
using HusbandForAnHour.DAL;
using HusbandForAnHour.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HusbandForAnHour.BLL
{
    public class StatusClient
    {
        private StatusRepository _statusRepository;
        private Mapper _mapper;

        public StatusClient()
        {
            _statusRepository = new StatusRepository();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new StatusMappingProfile());
            });
            _mapper = new Mapper(config);
        }
        public List<StatusOutputModel> GetStatuses()
        {
            List<StatusDto> statusDtos = _statusRepository.GetStatusById();
            return _mapper.Map<List<StatusOutputModel>>(statusDtos);


        }
    }
}
