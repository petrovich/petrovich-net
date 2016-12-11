using System.Collections.Generic;
using YamlDotNet.RepresentationModel.Serialization;

namespace NPetrovich.Rules.Data
{
    public class GenderRule
    {
        [YamlAlias("androgynous")]
        public List<string> Androgynous { get; set; }

        [YamlAlias("female")]
        public List<string> Female { get; set; }

        [YamlAlias("male")]
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