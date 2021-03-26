using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkApi.Utils
{
    class StringUtils
    {
        public static string GenerateRandomString(int size = 7)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Random random = new Random();

            char character;

            for (int i = 0; i < size; i++)
            {
                character = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                stringBuilder.Append(character);
            }

            return stringBuilder.ToString().ToLower();
        }
    }
}
