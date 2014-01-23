using NPetrovich.Inflection;
using NPetrovich.Rules;
using NPetrovich.Rules.Loader.Yaml;
using NPetrovich.Tests.TestDataProviders;
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
    }
}
