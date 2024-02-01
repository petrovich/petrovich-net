using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NPetrovich.Rules.Data
{
    public class RuleSet
    {
        [JsonPropertyName("exceptions")]
        public List<Rule> Exceptions { get; set; }
        
        [JsonPropertyName("suffixes")]
        public List<Rule> Suffixes { get; set; }
    }

    public class GenderRuleSet
    {
        [JsonPropertyName("exceptions")]
        public GenderRule Exceptions { get; set; }

        [JsonPropertyName("suffixes")]
        public GenderRule Suffixes { get; set; }
    }

}
