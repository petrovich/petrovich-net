
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace NPetrovich.Rules.Parser.Json
{
    public class JsonRulesParser : IRulesParser
    {
        public async Task<Data.Rules> ParseAsync(Stream data)
        {
            return await JsonSerializer.DeserializeAsync<Data.Rules>(data);
        }

        public async Task<Data.GenderRules> ParseGenderAsync(Stream data)
        {
            return (await JsonSerializer.DeserializeAsync<GenderContainer>(data))?.Gender;
        }
    }
}
