using System;
using System.Diagnostics;
using System.Management;
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

        public async Task<float> GetCurrentCpuUsage()
        {
            var first = _cpuCounter.NextValue();
            await Task.Delay(500);
            return _cpuCounter.NextValue();
        }

        public async Task<float> GetAvailableRAM()
        {
            var first = _ramCounter.NextValue();
            await Task.Delay(500);
            return _ramCounter.NextValue() / 1024;
        }

        public int GetTotalRAM()
        {
            string Query = "SELECT MaxCapacity FROM Win32_PhysicalMemoryArray";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(Query);
            foreach (ManagementObject WniPART in searcher.Get())
            {
                uint SizeinKB = Convert.ToUInt32(WniPART.Properties["MaxCapacity"].Value);
                UInt32 SizeinMB = SizeinKB / 1024;
                UInt32 SizeinGB = SizeinMB / 1024;
                Console.WriteLine("Size in KB: {0}, Size in MB: {1}, Size in GB: {2}", SizeinKB, SizeinMB, SizeinGB);
                return Convert.ToInt32(SizeinGB);
            }
            return 0;
        }
    }
}