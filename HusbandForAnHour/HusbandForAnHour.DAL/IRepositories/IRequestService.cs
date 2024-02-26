using HusbandForAnHour.DAL.Dtos;

public interface IRequestService
{
    void CreateRequestService(int idRequest, int idService);
    int DeleteRequestService(int idRequest);
    List<RequestServiceDto> GetRequestServiceByRequest(int idRequest);
    List<RequestServiceDto> GetRequestServiceByService(int idService);
}