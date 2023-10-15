namespace workersView.Interface
{
    public interface IWorkerRepo
    {
        //void Create(T user);
        // void Delete(int id);
        // T Get(int id);
        Task<List<T>> GetUsers<T>();
       // void Update(T user);
    }
}
