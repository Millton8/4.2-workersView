using Microsoft.AspNetCore.Authorization;
using System.Text.Json;
using workersView.Model;
using workersView.Repo;

namespace workersView
{
    public partial class Program
    {
        private async static Task RezOfWorkByUniq(HttpContext context, WorkerRepo workersDB, long uniq)
        {
            var report = await workersDB.GetRezOfWorkByUniq(uniq);
            context.Response.WriteAsJsonAsync(report);
        }


        [Authorize]
        private async static Task GetWorker(HttpContext context, WorkerRepo workersDB, long id)
        {
            var worker = await workersDB.Get(id);
            context.Response.WriteAsJsonAsync(worker);
        }

        [Authorize]
        private async static Task<IResult> Update(HttpContext context, WorkerRepo workersDB)
        {
            var worker = await context.Request.ReadFromJsonAsync<Worker>();

            try
            {
                await workersDB.UpdateWorkerInfo(worker);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return Results.Problem();
            }
            return Results.Ok();

        }
        [Authorize]
        private async static Task GetListofWork(HttpContext context, WorkerRepo workersDB)
        {
            var reportsList = await workersDB.GetGeneralReportAsync();
            var json = JsonSerializer.Serialize(reportsList);
            context.Response.WriteAsync(json);
        }
        [Authorize]
        private async static Task GetWorkers(HttpContext context, WorkerRepo workersDB)
        {
            var workers = await workersDB.GetRegistredWorkersAsync();
            context.Response.WriteAsJsonAsync(workers);
        }
        [Authorize]
        private async static Task WorkersStatus(HttpContext context, WorkerRepo workersDB)
        {
            var listStatus = await workersDB.GetWorkersStatusAsync();
            context.Response.WriteAsJsonAsync(listStatus);
        }
        [Authorize]
        private async static Task SalaryPerDate(HttpContext context, WorkerRepo workersDB, DateTime dateDo, DateTime datePosle)
        {
            var listStatus = await workersDB.GetWorkersSalary(dateDo.ToString(), datePosle.ToString());
            context.Response.WriteAsJsonAsync(listStatus);

        }
    }
}
