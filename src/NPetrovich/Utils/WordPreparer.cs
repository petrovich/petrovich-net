using System.Collections.Generic;
using System.Linq;

namespace NPetrovich.Utils
{
    internal static class WordPreparer
    {
        public static List<string> GetChunks(string name) => name?.Split('-').ToList() ?? new List<string>();
    }
}