using System.Collections.Generic;
using System.Linq;

namespace NPetrovich.Utils
{
    internal class SuffixMatching
    {
        private readonly string[] _charsArr;
        private readonly bool _entireWord;

        public SuffixMatching(IEnumerable<string> chars, bool entireWord)
        {
            _charsArr = chars?.ToArray();
            _entireWord = entireWord;
        }

        public bool IsMatched(string name)
        {
            if (_charsArr == null) return false;
            name = name.ToLower();
            return _charsArr.Any(chars => (
            _entireWord ?
                name :
                name.Substring(new[] { 0, name.Length - chars.Length }.Max())
                ).Equals(chars));
        }
    }
}