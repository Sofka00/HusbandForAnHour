using HusbandForAnHour.DAL.Dtos;

namespace HusbandForAnHour.DAL
{
    public interface ISpecializationRepository
    {
        List<SpecializationDto> CreateSpecialization();
        List<SpecializationDto> DeleteSpecialization();
        List<SpecializationDto> GetSpecializationById();
        List<SpecializationDto> UpdateSpecialization();
        List<SpecializationDto> GetAllSpecialization();

    }
}