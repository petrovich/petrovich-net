using System.IO;
using System.Threading.Tasks;

namespace NPetrovich.Rules.Parser
{
    public interface IRulesParser
    {
        Task<Data.Rules> ParseAsync(Stream data);
        Task<Data.GenderRules> ParseGenderAsync(Stream data);
    }
}