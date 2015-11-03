using System.IO;

namespace FileServerDashboard.Services
{
    public class DiskStatistics
    {
        private DriveInfo _drive = new DriveInfo("D");

        public double TotalSpace
        {
            get
            {
                return (double)_drive.TotalSize / 1024 / 1024 / 1024 / 1024;
            }
        }

        public double FreeSpace
        {
            get
            {
                return (double)_drive.AvailableFreeSpace / 1024 / 1024 / 1024 / 1024;
            }
        }

        public double UsedSpace
        {
            get
            {
                return TotalSpace - FreeSpace;
            }
        }
    }
}