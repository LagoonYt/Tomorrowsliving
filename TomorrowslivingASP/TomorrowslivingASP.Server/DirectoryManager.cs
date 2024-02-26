using System;
using System.IO;

namespace TomorrowsLiving
{
    public static class DirectoryManager
    {
        /// <summary>
        /// Ensures that the specified directory exists. If the directory does not exist, it will be created.
        /// </summary>
        /// <param name="path">The path of the directory to ensure existence.</param>
        public static void EnsureDirectoryExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Console.WriteLine($"{Path.GetFileName(path)} directory created.");
            }
        }
    }
}
