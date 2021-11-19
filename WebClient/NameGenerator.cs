using System;
using System.Linq;

namespace WebClient
{
    public static class NameGenerator
    {
        public static string GetRndString()
        {
            const string alphabet = "абвгдеёжзиклмнопрстуфхцчшщъыэюя";
            Random random = new Random();

            return new string(Enumerable.Repeat(alphabet, random.Next(3, 9))
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
