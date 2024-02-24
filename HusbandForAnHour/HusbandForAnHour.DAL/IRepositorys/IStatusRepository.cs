using HusbandForAnHour.DAL.Dtos;

namespace HusbandForAnHour.DAL.IRepositorys
{
    public interface IStatusRepository
    {
        List<StatusDto> CreateStatus();
        List<StatusDto> DeleteStatus();
        List<StatusDto> GetStatusById();
        List<StatusDto> UpdateStatus();
    }
}