using NPetrovich.Inflection;
using NPetrovich.Rules;
using NPetrovich.Rules.Loader.Yaml;
using NUnit.Framework;
using System;
using System.Collections;
using System.IO;
using System.Linq;

namespace NPetrovich.Tests.Fixtures
{
    [TestFixture]
    public class CaseInflectionFixture
    {
        private RulesProvider provider;

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            var loader = new YamlRulesLoader("rules.yml");
            provider = new RulesProvider(loader);
        }

        [Test]
        [TestCaseSource(typeof(InflectionTestCaseDataFactory), "InflectionData")]
        public void Should_inflect_first_name_correctly(string fullName, Gender gender, Case @case, string expected)
        {
            var inflection = new CaseInflection(provider, gender);
            var names = fullName.Split(' ');

            var lastName = inflection.InflectLastNameTo(names[0], @case);
            var firstName = inflection.InflectFirstNameTo(names[1], @case);
            var middleName = inflection.InflectMiddleNameTo(names[2], @case);
            Assert.AreEqual(expected, string.Format("{0} {1} {2}", lastName, firstName, middleName));
        }

        public class InflectionTestCaseDataFactory
        {
            public static IEnumerable InflectionData
            {
                get
                {
                    using (var reader = new StreamReader(Path.Combine("Data", "inflection.csv")))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (string.IsNullOrWhiteSpace(line))
                                continue;
                            
                            var chunks = line.Split(',').Select(s => s.Trim()).ToList();

                            var gender = (Gender) Enum.Parse(typeof (Gender), chunks[1]);
                            var @case = (Case) Enum.Parse(typeof (Case), chunks[2]);

                            yield return new object[] {chunks[0], gender, @case, chunks[3]};
                        }
                    }
                }
            }
        }

    }
}
