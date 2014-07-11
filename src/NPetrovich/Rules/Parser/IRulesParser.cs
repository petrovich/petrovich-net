using System.IO;

namespace NPetrovich.Rules.Parser
{
    public interface IRulesParser
    {
        Data.Rules Parse(StreamReader data);
    }
}