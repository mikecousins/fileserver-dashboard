using FileServerDashboard.Models;
using FileServerDashboard.Services;
using Microsoft.AspNet.Mvc;
using System.Threading.Tasks;

namespace FileServerDashboard.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Dashboard()
        {
            var viewModel = new DashboardViewModel();
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
