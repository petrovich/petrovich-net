using NPetrovich.Inflection;
using NPetrovich.Tests.TestDataProviders;
using NUnit.Framework;

namespace NPetrovich.Tests.Fixtures;

[TestFixture]
public class CaseInflectionFixtureStandalone
{
    [Test]
    [TestCaseSource(typeof(InflectionTestCaseDataFactory), nameof(InflectionTestCaseDataFactory.FirstNamesInflectionData))]
    public void Should_inflect_first_name_correctly(string firstName, Gender gender, Case @case, string expected)
    {
        var actual = new CaseInflection(gender).InflectFirstNameTo(firstName, @case);
        Assert.That(actual, Is.EqualTo(expected), $"Gender: {gender}, Case: {@case}");
    }

    [Test]
    [TestCaseSource(typeof(InflectionTestCaseDataFactory), nameof(InflectionTestCaseDataFactory.LastNamesInflectionData))]
    public void Should_inflect_last_name_correctly(string lastName, Gender gender, Case @case, string expected)
    {
        var actual = new CaseInflection(gender).InflectLastNameTo(lastName, @case);
        Assert.That(actual, Is.EqualTo(expected), $"Gender: {gender}, Case: {@case}");
    }

    [Test]
    [TestCaseSource(typeof(InflectionTestCaseDataFactory), nameof(InflectionTestCaseDataFactory.MiddleNamesInflectionData))]
    public void Should_inflect_middle_name_correctly(string middleName, Gender gender, Case @case, string expected)
    {
        var actual = new CaseInflection(gender).InflectMiddleNameTo(middleName, @case);
        Assert.That(actual, Is.EqualTo(expected), $"Gender: {gender}, Case: {@case}");
    }
}