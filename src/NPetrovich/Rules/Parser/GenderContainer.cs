using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using NPetrovich.Rules.Data;
using YamlDotNet.Serialization;

namespace NPetrovich.Rules.Parser
{
    class GenderContainer
    {
        [YamlMember(Alias = "gender")]
        [JsonProperty(PropertyName = "gender")]
        public GenderRules Gender { get; set; }
    }
}
