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
        [TestCaseSource(typeof(InflectionTestCaseDataFactory), "FirstNamesInflectionData")]
        public void Should_inflect_first_name_correctly(string firstName, Gender gender, Case @case, string expected)
        {
            var actual = new CaseInflection(provider, gender).InflectFirstNameTo(firstName, @case);
            Assert.AreEqual(expected, actual, string.Format("Gender: {0}, Case: {1}", gender, @case));
        }

        [Test]
        [TestCaseSource(typeof(InflectionTestCaseDataFactory), "LastNamesInflectionData")]
        public void Should_inflect_last_name_correctly(string lastName, Gender gender, Case @case, string expected)
        {
            var actual = new CaseInflection(provider, gender).InflectLastNameTo(lastName, @case);
            Assert.AreEqual(expected, actual, string.Format("Gender: {0}, Case: {1}", gender, @case));
        }

        [Test]
        [TestCaseSource(typeof(InflectionTestCaseDataFactory), "MiddleNamesInflectionData")]
        public void Should_inflect_middle_name_correctly(string middleName, Gender gender, Case @case, string expected)
        {
            var actual = new CaseInflection(provider, gender).InflectMiddleNameTo(middleName, @case);
            Assert.AreEqual(expected, actual, string.Format("Gender: {0}, Case: {1}", gender, @case));
        }

        public class InflectionTestCaseDataFactory
        {
            public static IEnumerable LastNamesInflectionData
            {
                get
                {
                    using (var reader = new StreamReader(Path.Combine("Data", "LastNames.csv")))
                    {
                        foreach (var p in ReadCaseData(reader)) yield return p;
                    }
                }
            }

            public static IEnumerable FirstNamesInflectionData
            {
                get
                {
                    using (var reader = new StreamReader(Path.Combine("Data", "FirstNames.csv")))
                    {
                        foreach (var p in ReadCaseData(reader)) yield return p;
                    }
                }
            }

            public static IEnumerable MiddleNamesInflectionData
            {
                get
                {
                    using (var reader = new StreamReader(Path.Combine("Data", "MiddleNames.csv")))
                    {
                        foreach (var p in ReadCaseData(reader)) yield return p;
                    }
                }
            }

            private static IEnumerable ReadCaseData(StreamReader reader)
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    var chunks = line.Split(',').Select(s => s.Trim()).ToList();

                    var gender = (Gender)Enum.Parse(typeof(Gender), chunks[1]);
                    var @case = (Case)Enum.Parse(typeof(Case), chunks[2]);

                    yield return new object[] { chunks[0], gender, @case, chunks[3] };
                }
            }

        }

    }
}
