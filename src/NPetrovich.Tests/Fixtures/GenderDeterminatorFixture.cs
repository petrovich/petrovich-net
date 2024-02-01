using NPetrovich.GenderDetermination;
using NUnit.Framework;

namespace NPetrovich.Tests.Fixtures;

[TestFixture]
public class GenderDeterminatorFixture
{
    public class Fio: IFio
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public override string ToString()
        {
            return $"{LastName}, {FirstName}, {MiddleName}";
        }
    }

    private GenderDeterminator _determinator;

    [OneTimeSetUp]
    public void FixtureSetUp()
    {
        _determinator = new GenderDeterminator(); 
    }

    [TestCaseSource(nameof(DeterminateCases))]
    public Gender Test(IFio fio)
    {
        return _determinator.Determinate(fio);
    }

    public static IEnumerable<TestCaseData> DeterminateCases
    {
        get
        {
            yield return new TestCaseData(new Fio {FirstName = "Александр" }).Returns(Gender.Male);
            yield return new TestCaseData(new Fio {LastName = "Склифасовский" }).Returns(Gender.Male);
            yield return new TestCaseData(new Fio { FirstName = "Александра" }).Returns(Gender.Female);
            yield return new TestCaseData(new Fio { LastName = "Склифасовская" }).Returns(Gender.Female);
            yield return new TestCaseData(new Fio { FirstName = "Александра", LastName = "Склифасовская" }).Returns(Gender.Female);
            yield return new TestCaseData(new Fio { FirstName = "Саша" }).Returns(Gender.Androgynous);
            yield return new TestCaseData(new Fio { FirstName = "Саша",LastName = "Андрейчук" }).Returns(Gender.Androgynous);
            yield return new TestCaseData(new Fio { FirstName = "Саша", LastName = "Иванов" }).Returns(Gender.Male);
            yield return new TestCaseData(new Fio { FirstName = "Саша", LastName = "Андрейчук", MiddleName = "Олегович"}).Returns(Gender.Male);
            yield return new TestCaseData(new Fio { FirstName = "Саша", MiddleName = "Олегович" }).Returns(Gender.Male);
            yield return new TestCaseData(new Fio { LastName = "Осипчук" }).Returns(Gender.Androgynous);
            yield return new TestCaseData(new Fio { MiddleName = "Олегович" }).Returns(Gender.Male);
            yield return new TestCaseData(new Fio { MiddleName = "Олеговна" }).Returns(Gender.Female);
            yield return new TestCaseData(new Fio()).Returns(Gender.Androgynous);
        }
    }
}