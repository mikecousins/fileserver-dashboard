using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileServerDashboard.Models
{
    public class ViewModel
    {
        public float CpuUsage { get; set; }

        public float MemoryUsage { get; set; }

        public double TotalArray { get; set; }

        public double FreeArray { get; set; }

        public double UsedArray { get; set; }

        public List<string> MovieNames { get; set; }

        public List<string> TVShowNames { get; set; }

        public int NumberOfPhotos { get; set; }
    }
}