using HusbandForAnHour.DAL;
using HusbandForAnHour.DAL.IRepositorys;
using HusbandForAnHour.DAL.Dtos;
using AutoMapper;
using HusbandForAnHour.BLL.Mapping;
using HusbandForAnHour.BLL.Models.OutputModels;
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
            List<ServicesDto> servicesDtos = _servicesRepositiry.GetServicesById();
           return  _mapper.Map<List<ServicesOutputModel>>(servicesDtos);

            
        }

    }
}
