using HusbandForAnHour.DAL.Dtos;

namespace HusbandForAnHour.DAL.IRepositories
{
    public interface IUserSpecializationRepository
    {
        void CreateUserSpecialization(long idUser, int idService);
        int DeleteUserSpecialization(long idUser);
        List<UserSpecializationDto> SelectUserSpecializationBySpecialization(int idSpecialization);
        List<UserSpecializationDto> SelectUserSpecializationByUser(long idUser);
    }
}