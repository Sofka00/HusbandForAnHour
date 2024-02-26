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
        public SpecializationService()
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

        public List<SpecializationOutputModel> GetAllSpecialization()
        {
            var dto = _repository.GetAllSpecialization();
            List<SpecializationOutputModel> result = new();
            foreach (var item in dto)
            {
                result.Add(_mapper.Map<SpecializationOutputModel>(dto));
            }
            return result;
        }

        public void CreateSpecialization(string name)
        {
            _repository.CreateSpecialization(name);
        }

        public int UpdateSpecialization(int specId,string name )
        {
            return _repository.UpdateSpecialization(specId, name);
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
