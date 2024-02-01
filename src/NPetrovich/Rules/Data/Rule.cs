using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NPetrovich.Rules.Data
{
    public class Rule
    {
        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("test")]
        public List<string> TestSuffixes { get; set; }

        [JsonPropertyName("mods")]
        public List<string> ModSuffixes { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }
    }
}
