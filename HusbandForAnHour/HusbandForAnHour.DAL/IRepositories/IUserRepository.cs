using HusbandForAnHour.DAL.Dtos;

namespace HusbandForAnHour.DAL.IRepositories
{
    public interface IUserRepository
    {
        void CreateUser(int roleId, string firstName, string secondName, long phone);
        int DeleteUser(long id);
        UserDto GetUser(long id);
        int RestoreUser(long id);
        int UpdateUser(long id, int roleId, string firstName, string secondName, long phone);
    }
}