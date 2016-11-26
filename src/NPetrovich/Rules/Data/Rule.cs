using System.Collections.Generic;
using Newtonsoft.Json;
using YamlDotNet.Serialization;

namespace NPetrovich.Rules.Data
{
    public class Rule
    {
        [YamlMember(Alias = "gender")]
        [JsonProperty(PropertyName = "gender")]
        public string Gender { get; set; }

        [YamlMember(Alias = "test")]
        [JsonProperty(PropertyName = "test")]
        public List<string> TestSuffixes { get; set; }

        [YamlMember(Alias = "mods")]
        [JsonProperty(PropertyName = "mods")]
        public List<string> ModSuffixes { get; set; }

        [YamlMember(Alias = "tags")]
        [JsonProperty(PropertyName = "tags")]
        public List<string> Tags { get; set; }
    }
}
