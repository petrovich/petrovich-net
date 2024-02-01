using NUnit.Framework;

namespace NPetrovich.Tests.Fixtures;

[TestFixture]
public class PetrovichFixture
{
    [Test]
    [TestCase("Петрович", Gender.Male)]
    [TestCase("Петровна", Gender.Female)]
    [TestCase("Петрович Оглы", Gender.Male)]
    [TestCase("Петровна Кызы", Gender.Female)]
    public void Should_detect_gender_if_auto_detection_is_set(string middleName, Gender expected)
    {
        var petrovich = new Petrovich {AutoDetectGender = true, MiddleName = middleName};
        petrovich.InflectMiddleNameTo(Case.Accusative);

        Assert.That(petrovich.Gender, Is.EqualTo(expected));
    }

    [Test]
    [TestCase("Петрович")]
    [TestCase("Петровна")]
    public void Should_not_detect_gender_if_auto_detection_is_not_set(string middleName)
    {
        var petrovich = new Petrovich { AutoDetectGender = false, MiddleName = middleName };
        petrovich.InflectMiddleNameTo(Case.Accusative);

        Assert.That(petrovich.Gender, Is.EqualTo(Gender.Androgynous));
    }

    [Test]
    public void Should_throw_ArgumentNullException_if_first_name_is_not_provided()
    {
        var petrovich = new Petrovich();

        Assert.Throws<ArgumentNullException>(() => petrovich.InflectFirstNameTo(Case.Accusative));
    }

    [Test]
    public void Should_throw_ArgumentNullException_if_last_name_is_not_provided()
    {
        var petrovich = new Petrovich();

        Assert.Throws<ArgumentNullException>(() => petrovich.InflectLastNameTo(Case.Accusative));
    }

    [Test]
    public void Should_throw_ArgumentNullException_if_middle_name_is_not_provided()
    {
        var petrovich = new Petrovich();

        Assert.Throws<ArgumentNullException>(() => petrovich.InflectMiddleNameTo(Case.Accusative));
    }

    [Test]
    [TestCase("Петр", "Петров", "")]
    [TestCase("Петр", "", "Петрович")]
    [TestCase("", "Петров", "Петрович")]
    [TestCase(null, "Петров", "Петрович")]
    [TestCase("Петр", null, "Петрович")]
    [TestCase("Петр", "Петров", null)]
    [TestCase(" ", "Петров", "Петрович")]
    [TestCase("Петр", " ", "Петрович")]
    [TestCase("Петр", "Петров", " ")]
    [TestCase(null, "", " ")]
    public void Should_throw_ArgumentNullException_if_any_name_is_not_provided(string firstName, string lastName, string middleName)
    {
        var petrovich = new Petrovich();

        Assert.Throws<ArgumentNullException>(() => petrovich.InflectTo(Case.Accusative));
    }

    [Test]
    public void Should_return_full_name_if_cast_to_string()
    {
        var petrovich = new Petrovich {FirstName = "Петр", LastName = "Петров", MiddleName = "Петрович"};

        Assert.That(petrovich.ToString(), Is.EqualTo("Петров Петр Петрович"));
    }
}