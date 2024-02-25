using HusbandForAnHour.DAL.Dtos;

namespace HusbandForAnHour.DAL
{
    public interface IRequestRepository
    {
        List<RequestDto> CreateRequest();
        List<RequestDto> DeleteRequestById();
        List<GetAllRequestDto> GetAllRequest();
        List<RequestDto> GetRequestById();
        List<RequestDto> UpdateRequest();
    }
}