using FileServerDashboard.Models;
using FileServerDashboard.Services;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Mvc;

namespace FileServerDashboard.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var viewModel = new ViewModel();
            var performance = new PerformanceStatistics();
            viewModel.CpuUsage = await performance.getCurrentCpuUsage();
            viewModel.MemoryUsage = await performance.getAvailableRAM();
            var disk = new DiskStatistics();
            viewModel.FreeArray = disk.FreeSpace;
            viewModel.TotalArray = disk.TotalSpace;
            viewModel.UsedArray = disk.UsedSpace;
            viewModel.MovieNames = disk.MovieTitles;
            viewModel.TVShowNames = disk.TvShowTitles;
            //viewModel.NumberOfPhotos = disk.NumberOfPhotos;
            return View(viewModel);
        }

        public async Task<JsonResult> CurrentCpuPercentage()
        {
            var performance = new PerformanceStatistics();
            return Json(await performance.getCurrentCpuUsage());
        }

        public async Task<JsonResult> CurrentRamAvailable()
        {
            var performance = new PerformanceStatistics();
            return Json(await performance.getAvailableRAM());
        }
    }
}