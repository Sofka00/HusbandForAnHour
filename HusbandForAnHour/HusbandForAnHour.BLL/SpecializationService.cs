using AutoMapper;
using HusbandForAnHour.BLL.Mapping;
using HusbandForAnHour.BLL.Models.InputModels;
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
    public class SpecializationService
    {
        private SpecializationRepository _repository;
        private Mapper _mapper;
        public SpecializationService ()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new SpecializationMappingProfile());
            });
            _mapper = new Mapper(config);
            _repository = new SpecializationRepository();
        }

        public SpecializationOutputModel GetSpecialization(int id)
        {
            var dto = _repository.GetSpecialization(id);
            return _mapper.Map<SpecializationOutputModel>(dto);
        }

        public void CreateSpecialization(SpecializationDto specializationDto)
        {
            _repository.CreateSpecialization(specializationDto.Name);
        }

        public int UpdateSpecialization(SpecializationDto specializationDto)
        {
            return _repository.UpdateSpecialization(specializationDto.Id, specializationDto.Name);
        }

        public int DeleteSpecialization(int id)
        {
            return _repository.DeleteSpecialization(id);
        }

        public int RestoreSpecialization(int id)
        {
            return _repository.RestoreSpecialization(id);
        }
    }
}
    }
}
