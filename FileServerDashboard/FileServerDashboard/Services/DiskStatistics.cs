using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileServerDashboard.Services
{
    public class DiskStatistics
    {
        private DriveInfo _drive = new DriveInfo("D");
        private DirectoryInfo _movieFolder = new DirectoryInfo(@"D:\Videos\Movies");
        private DirectoryInfo _tvFolder = new DirectoryInfo(@"D:\Videos\TV Shows");
        private DirectoryInfo _photoFolder = new DirectoryInfo(@"D:\Photos");

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

        public List<string> MovieTitles
        {
            get
            {
                var movieTitles = new List<string>();
                var movies = _movieFolder.GetDirectories();
                foreach (var movie in movies)
                {
                    movieTitles.Add(movie.Name);
                }
                movieTitles.Sort();
                return movieTitles;
            }
        }

        public List<string> TvShowTitles
        {
            get
            {
                var tvShowTitles = new List<string>();
                var tvShows = _tvFolder.GetDirectories();
                foreach (var tvShow in tvShows)
                {
                    tvShowTitles.Add(tvShow.Name);
                }
                tvShowTitles.Sort();
                return tvShowTitles;
            }
        }

        public int NumberOfPhotos
        {
            get
            {
                return _photoFolder.GetFiles("*", SearchOption.AllDirectories).Length;
            }
        }
    }
}