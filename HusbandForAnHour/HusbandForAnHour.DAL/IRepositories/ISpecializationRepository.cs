using HusbandForAnHour.DAL.Dtos;

namespace HusbandForAnHour.DAL.IRepositories
{
    public interface ISpecializationRepository
    {
        void CreateSpecialization(string name);
        int DeleteSpecialization(int id);
        SpecializationDto GetSpecialization(int id);
        int RestoreSpecialization(int id);
        int UpdateSpecialization(int id, string name);
    }
}