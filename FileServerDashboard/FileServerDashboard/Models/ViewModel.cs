using System.Collections.Generic;

namespace FileServerDashboard.Models
{
    public class ViewModel
    {
        public float CpuUsage { get; set; }

        public float MemoryAvailable { get; set; }

        public int TotalMemory { get; set; }

        public string MemoryUsage
        {
            get
            {
                return (TotalMemory - MemoryAvailable).ToString("#.##") + "/" + TotalMemory + "GB";
            }
        }

        public double TotalArray { get; set; }

        public double FreeArray { get; set; }

        public double UsedArray { get; set; }

        public List<string> MovieNames { get; set; }

        public List<string> TVShowNames { get; set; }

        public int NumberOfPhotos { get; set; }
    }
}