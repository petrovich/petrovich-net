using System;
using System.IO;
using Newtonsoft.Json;

namespace NPetrovich.Rules.Parser.Json
{
    public class JsonRulesParser : IRulesParser
    {
        public Data.Rules Parse(StreamReader data)
        {
            string json = data.ReadToEnd();
            return JsonConvert.DeserializeObject<Data.Rules>(json);
        }
    }
}
