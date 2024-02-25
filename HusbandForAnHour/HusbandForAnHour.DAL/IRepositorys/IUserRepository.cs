using HusbandForAnHour.DAL.Dtos;

namespace HusbandForAnHour.DAL.IRepositorys
{
    public interface IUserRepository
    {
        UserDto CreateUser(UserDto userDto);
        List<UserDto> DeleteUser();
        List<UserDto> GetUserById();
        List<UserDto> UpdateUser();
    }
}