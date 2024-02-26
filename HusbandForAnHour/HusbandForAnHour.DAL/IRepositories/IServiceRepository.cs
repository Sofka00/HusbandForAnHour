using HusbandForAnHour.DAL.Dtos;

namespace HusbandForAnHour.DAL.IRepositories
{
    public interface IServiceRepository
    {
        void CreateService(string name, int specializationId);
        int DeleteService(int id);
        ServicesDto GetService(int id);
        List<ServicesDto> GetServiceBySpecialization(int id);
        int RestoreService(int id);
        int UpdateService(int id, string name, int specializationId);
    }
}