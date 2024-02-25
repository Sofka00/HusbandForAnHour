using HusbandForAnHour.DAL;
using HusbandForAnHour.DAL.IRepositorys;
using HusbandForAnHour.DAL.Dtos;
using AutoMapper;
using HusbandForAnHour.BLL.Mapping;
using HusbandForAnHour.BLL.Models.OutputModels;
using HusbandForAnHour.BLL.Models.InputModels;
namespace HusbandForAnHour.BLL
{
    public class ServicesClient
    {
        private ServicesRepositiry _servicesRepositiry;
        private Mapper _mapper;
        public ServicesClient()
        {
            _servicesRepositiry = new ServicesRepositiry();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ServicesMappingProfile());
            });
                _mapper = new Mapper(config);

        }
        public List <ServicesOutputModel> GetServices()
        {
            List<ServicesDto> servicesDtos = _servicesRepositiry.GetAllServices();
           return  _mapper.Map<List<ServicesOutputModel>>(servicesDtos);

            
        }
        public ServicesOutputModel CreateServices(CreateServicesInputModel inputModel)
        {
           var convertServicesDto= _mapper.Map<ServicesDto>(inputModel);
            ServicesDto servicesDto = _servicesRepositiry.CreateServices(convertServicesDto);
           return _mapper.Map<ServicesDto, ServicesOutputModel>(servicesDto);
        }

    }
}
