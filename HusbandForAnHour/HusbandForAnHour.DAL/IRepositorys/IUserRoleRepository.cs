using HusbandForAnHour.DAL.Dtos;

namespace HusbandForAnHour.DAL
{
    public interface IUserRoleRepository
    {
        List<UserRoleDto> CreateUserRole();
        List<UserRoleDto> DeleteUserRoleById();
        List<UserRoleDto> GetUserRoleById();
        List<UserRoleDto> UpdateUserRole();
    }
}