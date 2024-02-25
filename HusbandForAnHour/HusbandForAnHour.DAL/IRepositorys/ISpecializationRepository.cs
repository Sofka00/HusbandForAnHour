using HusbandForAnHour.DAL.Dtos;

namespace HusbandForAnHour.DAL
{
    public interface ISpecializationRepository
    {
        SpecializationDto CreateSpecialization(SpecializationDto specializationDto);
        List<SpecializationDto> DeleteSpecialization();
        List<SpecializationDto> GetSpecializationById();
        List<SpecializationDto> UpdateSpecialization();
        List<SpecializationDto> GetAllSpecialization();
        int GetLastSpecializationId();
    }
}