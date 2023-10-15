using workersView.Model;

namespace workersView.Interface
{
    public interface IDataRepo
    {
        Task<T> Get<T>(string tableName, string connectionId, long id);
        Task<List<T>> GetUserReportByUniq<T>(string tableName, string connectionId, long uniq);
        Task<List<T>> GetUsers<T>(string tableName, string connectionId);
        Task<List<T>> GetUsersStatus<T>(string connectionId);
        Task<List<T>> GetUsersSalarySumPerDate<T>(string tableName, string connectionId, string dataDo, string dataPosle);
        Task UpdateUser<T>(string tableName, string connectionId, T user);
    }
}