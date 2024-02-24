using HusbandForAnHour.DAL.Dtos;

namespace HusbandForAnHour.DAL
{
    public interface IRequestRepository
    {
        List<RequestDto> CreateRequest();
        List<RequestDto> DeleteRequestById();
        List<RequestDto> GetAllRequest();
        List<RequestDto> GetRequestById();
        List<RequestDto> UpdateRequest();
    }
}