using AutoMapper;
using HusbandForAnHour.BLL.Mapping;
using HusbandForAnHour.BLL.Models.OutputModels;
using HusbandForAnHour.DAL;
using HusbandForAnHour.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusbandForAnHour.BLL
{
    public class SpecializationClient
    {
        private SpecializationRepository _specializationRepository;
        private Mapper _mapper;
        public SpecializationClient ()
        {
            _specializationRepository = new SpecializationRepository();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new SpecializationMappingProfile());
            });
            _mapper = new Mapper(config);
        }
        public List<GetAllSpecializationOutputModel> GetSpecializations()
        {
            List<SpecializationDto> specializationsDtos = _specializationRepository.GetAllSpecialization();
            return _mapper.Map < List<GetAllSpecializationOutputModel>>(specializationsDtos);
        }
    }
}
