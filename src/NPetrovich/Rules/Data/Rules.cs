using Newtonsoft.Json;
using YamlDotNet.Serialization;

namespace NPetrovich.Rules.Data
{
    public class Rules
    {
        [YamlMember(Alias = "lastname")]
        [JsonProperty(PropertyName = "lastname")]
        public RuleSet LastName { get; set; }

        [YamlMember(Alias = "firstname")]
        [JsonProperty(PropertyName = "firstname")]
        public RuleSet FirstName { get; set; }

        [YamlMember(Alias = "middlename")]
        [JsonProperty(PropertyName = "middlename")]
        public RuleSet MiddleName { get; set; }
    }
}
