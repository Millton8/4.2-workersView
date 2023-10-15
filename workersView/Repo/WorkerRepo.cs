using workersView.Interface;
using workersView.Model;

namespace workersView.Repo
{
    public class WorkerRepo
    {
        private readonly IDataRepo _repo;
       // private readonly string con=""

        public WorkerRepo(IDataRepo repo)
        {
            _repo = repo;
        }
        public async Task<Worker> Get(long id)
        {
            return await _repo.Get<Worker>("workerinfo", "PostgreDb",id);
        }
        public async Task<List<WorkerSalary>> GetWorkersSalary(string dateDo, string datePosle)
        {
            return await _repo.GetUsersSalarySumPerDate<WorkerSalary>("rezofwork", "PostgreDb", dateDo, datePosle);
        }
        public async Task<List<WorkRezult>> GetRezOfWorkByUniq(long uniq)
        {
            return await _repo.GetUserReportByUniq<WorkRezult>("rezofwork", "PostgreDb", uniq);
        }

        public async Task<List<WorkRezult>> GetGeneralReportAsync()
        {
           return await _repo.GetUsers<WorkRezult>("rezofwork", "PostgreDb");
        }
        public async Task<List<Worker>> GetRegistredWorkersAsync()
        {
            return await _repo.GetUsers<Worker>("workerinfo", "PostgreDb");
        }

        public async Task<List<WorkerStatus>> GetWorkersStatusAsync()
        {
            return await _repo.GetUsersStatus<WorkerStatus>("PostgreDb");

        }

        public async Task UpdateWorkerInfo(Worker worker)
        {
            await _repo.UpdateUser("workerinfo", "PostgreDb",worker);
        }

    }
}
