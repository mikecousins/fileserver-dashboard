using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FileServerDashboard.Services
{
    public class DiskStatistics
    {
        public double GetTotalSpace()
        {
            var drive = new DriveInfo("D");
            return drive.TotalSize;
        }
    }
}