using System.Collections.Generic;
using Newtonsoft.Json;
using YamlDotNet.Serialization;

namespace NPetrovich.Rules.Data
{
    public class RuleSet
    {
        [YamlMember(Alias = "exceptions")]
        [JsonProperty(PropertyName = "exceptions")]
        public List<Rule> Exceptions { get; set; }

        [YamlMember(Alias = "suffixes")]
        [JsonProperty(PropertyName = "suffixes")]
        public List<Rule> Suffixes { get; set; }
    }
}
