using System.Collections.Generic;
using Newtonsoft.Json;
using YamlDotNet.Serialization;

namespace NPetrovich.Rules.Data
{
    public class GenderRule
    {
        [YamlMember(Alias = "androgynous")]
        [JsonProperty(PropertyName = "androgynous")]
        public List<string> Androgynous { get; set; }

        [YamlMember(Alias = "female")]
        [JsonProperty(PropertyName = "female")]
        public List<string> Female { get; set; }

        [YamlMember(Alias = "male")]
        [JsonProperty(PropertyName = "male")]
        public List<string> Male { get; set; }

        public List<string> this[Gender gender]
        {
            get
            {
                switch (gender)
                {
                    case Gender.Androgynous:
                        return Androgynous;
                    case Gender.Female:
                        return Female;
                    case Gender.Male:
                        return Male;
                    default:
                        return new List<string>();
                }
            }
        }
    }
}