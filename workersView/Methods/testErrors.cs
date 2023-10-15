using Microsoft.IdentityModel.Tokens;
using workersView.Repo;

namespace workersView
{
    public partial class Program
    {
        private async static Task test(HttpContext context, WorkerRepo workersDB)
        {
            int a = 2, b = 0;
            var c = a / b;
        }
    }
}
