using NPetrovich.Inflection;
using NPetrovich.Tests.TestDataProviders;
using NUnit.Framework;

namespace NPetrovich.Tests.Fixtures
{
    [TestFixture]
    public class CaseInflectionFixtureStandalone
    {
        [Test]
        [TestCaseSource(typeof(InflectionTestCaseDataFactory), "FirstNamesInflectionData")]
        public void Should_inflect_first_name_correctly(string firstName, Gender gender, Case @case, string expected)
        {
            var actual = new CaseInflection(gender).InflectFirstNameTo(firstName, @case);
            Assert.AreEqual(expected, actual, string.Format("Gender: {0}, Case: {1}", gender, @case));
        }

        [Test]
        [TestCaseSource(typeof(InflectionTestCaseDataFactory), "LastNamesInflectionData")]
        public void Should_inflect_last_name_correctly(string lastName, Gender gender, Case @case, string expected)
        {
            var actual = new CaseInflection(gender).InflectLastNameTo(lastName, @case);
            Assert.AreEqual(expected, actual, string.Format("Gender: {0}, Case: {1}", gender, @case));
        }

        [Test]
        [TestCaseSource(typeof(InflectionTestCaseDataFactory), "MiddleNamesInflectionData")]
        public void Should_inflect_middle_name_correctly(string middleName, Gender gender, Case @case, string expected)
        {
            var actual = new CaseInflection(gender).InflectMiddleNameTo(middleName, @case);
            Assert.AreEqual(expected, actual, string.Format("Gender: {0}, Case: {1}", gender, @case));
        }
    }
}
