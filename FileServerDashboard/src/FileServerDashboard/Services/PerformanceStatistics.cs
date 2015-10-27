using System.Diagnostics;
using System.Threading.Tasks;

namespace FileServerDashboard.Services
{
    public class PerformanceStatistics
    {
        PerformanceCounter _cpuCounter;
        PerformanceCounter _ramCounter;

        public PerformanceStatistics()
        {
            _cpuCounter = new PerformanceCounter();

            _cpuCounter.CategoryName = "Processor";
            _cpuCounter.CounterName = "% Processor Time";
            _cpuCounter.InstanceName = "_Total";

            _ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        }

        public async Task<float> getCurrentCpuUsage()
        {
            var first = _cpuCounter.NextValue();
            await Task.Delay(500);
            return _cpuCounter.NextValue();
        }

        public async Task<float> getAvailableRAM()
        {
            var first = _ramCounter.NextValue();
            await Task.Delay(500);
            return _ramCounter.NextValue();
        }
    }
}
