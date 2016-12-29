using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using NPetrovich.Rules.Data;

namespace NPetrovich.Rules.Parser.Json
{
    public class JsonRulesParser : IRulesParser
    {
        public Data.Rules Parse(StreamReader data)
        {
            return JsonConvert.DeserializeObject<Data.Rules>(data.ReadToEnd());
        }

        public Data.GenderRules ParseGender(StreamReader data)
        {
            return JsonConvert.DeserializeObject<GenderContainer>(data.ReadToEnd()).Gender;
        }
    }
}
