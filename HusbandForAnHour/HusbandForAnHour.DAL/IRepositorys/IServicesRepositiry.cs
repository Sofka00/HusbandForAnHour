using HusbandForAnHour.DAL.Dtos;

namespace HusbandForAnHour.DAL.IRepositorys
{
    public interface IServicesRepositiry
    {
        List<ServicesDto> CreateServices();
        List<ServicesDto> DeleteServices();
        List<ServicesDto> GetServicesById();
        List<ServicesDto> UpdateServices();
        List<ServicesDto> GetAllServices();
    }
}