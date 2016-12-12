using System.IO;

namespace NPetrovich.Rules.Parser
{
    public interface IRulesParser
    {
        Data.Rules Parse(StreamReader data);
        Data.GenderRules ParseGender(StreamReader data);
    }
}