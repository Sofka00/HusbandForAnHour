using HusbandForAnHour.DAL.Dtos;

namespace HusbandForAnHour.DAL.IRepositorys
{
    public interface IServicesRepositiry
    {
        void CreateServices(ServicesDto servicesDto);
        List<ServicesDto> DeleteServices();
        List<ServicesDto> GetServicesById();
        List<ServicesDto> UpdateServices();
        List<ServicesDto> GetAllServices();
    }
}