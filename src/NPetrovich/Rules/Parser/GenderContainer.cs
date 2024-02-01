using System.Text.Json.Serialization;
using NPetrovich.Rules.Data;

namespace NPetrovich.Rules.Parser
{
    class GenderContainer
    {
        [JsonPropertyName("gender")]
        public GenderRules Gender { get; set; }
    }
}
