
using System.Text.Json.Serialization;

namespace NPetrovich.Rules.Data
{
    public class Rules<TItem>
    {
        [JsonPropertyName("lastname")]
        public TItem LastName { get; set; }
        
        [JsonPropertyName("firstname")]
        public TItem FirstName { get; set; }
        
        [JsonPropertyName("middlename")]
        public TItem MiddleName { get; set; }
    }


    public class Rules: Rules<RuleSet>
    {
    }

    public class GenderRules : Rules<GenderRuleSet>
    {
    }
}
