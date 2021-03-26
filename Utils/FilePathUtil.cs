using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkApi.Utils
{
    class FilePathUtil
    {
        public static string GetFilePath(string pathToFile)
        {
            string dirName = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo parentDir = new FileInfo(dirName).Directory.Parent.Parent;
            return parentDir.FullName + pathToFile;
        }
    }
}
