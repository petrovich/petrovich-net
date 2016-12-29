using System.IO;
using Newtonsoft.Json;
using NPetrovich.Rules.Data;
using YamlDotNet.Serialization;

namespace NPetrovich.Rules.Parser.Yaml
{
    public class YamlRulesParser : IRulesParser
    {
        public Data.Rules Parse(StreamReader data)
        {
            return new Deserializer().Deserialize<Data.Rules>(data);
        }

        public GenderRules ParseGender(StreamReader data)
        {
            return new Deserializer().Deserialize<GenderContainer>(data).Gender;
        }
    }
}
