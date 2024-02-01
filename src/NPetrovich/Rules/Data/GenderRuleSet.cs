﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NPetrovich.Rules.Data
{
    public class GenderRule
    {
        [JsonPropertyName("androgynous")]
        public List<string> Androgynous { get; set; }

        [JsonPropertyName("female")]
        public List<string> Female { get; set; }

        [JsonPropertyName("male")]
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