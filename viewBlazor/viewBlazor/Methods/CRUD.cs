using System.Net;
using viewBlazor.Models;

namespace viewBlazor.Methods
{
        public class CRUD
        {
            HttpClient httpClient;
            public CRUD(IHttpClientFactory ClientFactory)
            {

                httpClient = ClientFactory.CreateClient();
            }
            public async Task<List<WorkRezult>> GetGeneralReport()
            {
                
                var response = await httpClient.GetAsync($"https://localhost:5002/list");
                return await response.Content.ReadFromJsonAsync<List<WorkRezult>>();

            }
        public async Task<Worker> GetWorker(long id)
        {

            var response = await httpClient.GetAsync($"https://localhost:5002/get/{id}");
            return await response.Content.ReadFromJsonAsync<Worker>();

        }
        public async Task<List<WorkerStatus>> GetWorkersStatus()
        {

            var response = await httpClient.GetAsync($"https://localhost:5002/status");
            return await response.Content.ReadFromJsonAsync<List<WorkerStatus>>();

        }
        public async Task<List<Worker>> GetWorkers()
            {

                var response = await httpClient.GetAsync($"https://localhost:5002/listworkers");
                return await response.Content.ReadFromJsonAsync<List<Worker>>();

            }
            public async Task<HttpStatusCode> UpdateWorker(Worker worker)
            {

                
                var response = await httpClient.PutAsJsonAsync("https://localhost:5002/update", worker);
                return response.StatusCode;


            }

        }
    
}
