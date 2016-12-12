using System.IO;
using NPetrovich.Rules.Data;
using YamlDotNet.RepresentationModel.Serialization;

namespace NPetrovich.Rules.Parser.Yaml
{
    public class YamlRulesParser : IRulesParser
    {
        class GenderContainer
        {
            [YamlAlias("gender")]
            public GenderRules Gender { get; set; }
        }

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
