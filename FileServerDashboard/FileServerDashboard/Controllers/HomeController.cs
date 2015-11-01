using FileServerDashboard.Models;
using FileServerDashboard.Services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FileServerDashboard.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var viewModel = new ViewModel();
            var stats = new PerformanceStatistics();
            viewModel.CpuUsage = await stats.getCurrentCpuUsage();
            viewModel.MemoryUsage = await stats.getAvailableRAM();
            viewModel.FreeArray = 1;
            viewModel.TotalArray = 2;
            viewModel.UsedArray = 3;
            return View(viewModel);
        }
    }
}