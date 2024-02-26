using HusbandForAnHour.DAL.Dtos;

namespace HusbandForAnHour.DAL.IRepositories
{
    public interface IStatusRepository
    {
        void CreateStatus(string name);
        int DeleteStatus(int id);
        StatusDto GetStatus(int id);
        int RestoreStatus(int id);
        int UpdateStatus(int id, string name);
    }
}