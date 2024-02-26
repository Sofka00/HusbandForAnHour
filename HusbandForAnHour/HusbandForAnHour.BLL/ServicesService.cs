using HusbandForAnHour.DAL.Dtos;
using AutoMapper;
using HusbandForAnHour.BLL.Mapping;
using HusbandForAnHour.BLL.Models.OutputModels;
using HusbandForAnHour.BLL.Models.InputModels;
using HusbandForAnHour.DAL;
namespace HusbandForAnHour.BLL
{
    public class ServicesService
    {
        private ServiceRepository _repository;
        private SpecializationService _specializationService;
        private Mapper _mapper;
        public ServicesService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ServicesMappingProfile());
            });
                _mapper = new Mapper(config);
            _repository = new ServiceRepository();
            _specializationService = new SpecializationService();
        }

        public ServicesOutputModel GetService(int id)
        {
            var dto = _repository.GetService(id);
            var result = _mapper.Map<ServicesOutputModel>(dto);
            result.Specialization = _specializationService.GetSpecialization(dto.SpecializationId);
            return result;
        }

        public List<ServicesOutputModel> GetServiceBySpecialization(int id)
        {
            var dtos = _repository.GetServiceBySpecialization(id);
            return _mapper.Map<List<ServicesOutputModel>>(dtos);
        }

        public void CreateService(ServicesDto servicesDto)
        {
            _repository.CreateService(servicesDto.Name, servicesDto.SpecializationId);
        }

        public int DeleteService(int id)
        {
            return _repository.DeleteService(id);
        }

        public int RestoreService(int id)
        {
            return _repository.RestoreService(id);
        }

        public int UpdateService(ServicesDto servicesDto)
        {
            return _repository.UpdateService(servicesDto.Id, servicesDto.Name, servicesDto.SpecializationId);
        }
    }
}
