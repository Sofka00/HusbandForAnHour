using HusbandForAnHour.DAL.Dtos;

public interface IRequestWorkerRepository
{
    void CreateRequestWorker(int idRequest, long idWorker);
    int DeleteRequestWorker(int idRequest);
    List<RequestWorkerDto> SelectRequestWorkerByRequest(int idRequest);
    List<RequestWorkerDto> SelectRequestWorkerByWorker(int idWorker);
}