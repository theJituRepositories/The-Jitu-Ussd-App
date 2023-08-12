using System;

namespace library_service
{
    public static class PathManager
    {
        private static string _path = @"D:\c#\Jitu_Ssd"; // Default path

        public static string Path
        {
            get { return _path; }
            set { _path = value; }
        }
    }
}