using HusbandForAnHour.DAL.Dtos;

public interface IRequestRepository
{
    void CreateRequest(long clientId, DateTime date, string address, int statusId, string comment);
    int DeleteRequest(int id);
    RequestDto GetRequest(int id);
    List<RequestDto> GetRequestByClient(long clientId);
    int RestoreRequest(int id);
    int UpdateRequest(int id, long clientId, DateTime date, string address, int statusId, string comment);
}