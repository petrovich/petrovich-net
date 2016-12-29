using Newtonsoft.Json;
using YamlDotNet.Serialization;

namespace NPetrovich.Rules.Data
{
    public class Rules<TItem>
    {
        [YamlMember(Alias = "lastname")]
        [JsonProperty(PropertyName = "lastname")]
        public TItem LastName { get; set; }
        
        [YamlMember(Alias = "firstname")]
        [JsonProperty(PropertyName = "firstname")]
        public TItem FirstName { get; set; }
        
        [YamlMember(Alias = "middlename")]
        [JsonProperty(PropertyName = "middlename")]
        public TItem MiddleName { get; set; }
    }


    public class Rules: Rules<RuleSet>
    {
    }

    public class GenderRules : Rules<GenderRuleSet>
    {
    }
}
