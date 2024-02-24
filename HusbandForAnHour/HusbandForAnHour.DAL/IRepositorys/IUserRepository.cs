using HusbandForAnHour.DAL.Dtos;

namespace HusbandForAnHour.DAL.IRepositorys
{
    public interface IUserRepository
    {
        List<UserDto> CreateUser();
        List<UserDto> DeleteUser();
        List<UserDto> GetUserById();
        List<UserDto> UpdateUser();
    }
}