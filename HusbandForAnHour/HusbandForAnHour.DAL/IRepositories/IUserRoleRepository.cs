using HusbandForAnHour.DAL.Dtos;

namespace HusbandForAnHour.DAL.IRepositories
{
    public interface IUserRoleRepository
    {
        void CreateUserRole(string name);
        int DeleteUserRole(int id);
        UserRoleDto GetUserRole(int id);
        int RestoreUserRole(int id);
        int UpdateUserRole(int id, string name);
    }
}