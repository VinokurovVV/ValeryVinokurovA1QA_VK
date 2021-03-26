using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkApi.Utils
{
    class JsonReader
    {
        private static readonly string pathToTestDataFile = @"\Resources\TestData.json";

        public static string GetParameterFromDataFile(string parameterName)
        {
            var data = JObject.Parse(File.ReadAllText(FilePathUtil.GetFilePath(pathToTestDataFile)));
            return (string)data[parameterName];
        }

        public static string GetParameterFromDataFile(string parameterName, int arrayIndex)
        {
            var data = JObject.Parse(File.ReadAllText(FilePathUtil.GetFilePath(pathToTestDataFile)));
            return (string)data[parameterName][arrayIndex];
        }
    }
}
