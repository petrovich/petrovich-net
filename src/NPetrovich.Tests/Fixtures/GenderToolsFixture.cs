using System;
using NPetrovich.Utils;
using NUnit.Framework;

namespace NPetrovich.Tests.Fixtures
{
    [TestFixture]
    public class GenderToolsFixture
    {
        [Test]
        [TestCase("Иванович", Gender.Male)]
        [TestCase("Ивановна", Gender.Female)]
        [TestCase("Иванович ОГЛЫ", Gender.Male)]
        [TestCase("Ивановна-кызы", Gender.Female)]
        [TestCase("Абракадабра", Gender.Androgynous)]
        public void Should_detect_gender_using_extension_method(string middleName, Gender expectedGender)
        {
            var actualGender = GenderUtils.Detect(middleName);
            Assert.AreEqual(expectedGender, actualGender);
        }

        [Test]
        [TestCase("asdasd")]
        [TestCase("абракадабра")]
        public void Should_not_throw_exception_if_gender_can_not_be_detected(string middleName)
        {
            Assert.DoesNotThrow(() => GenderUtils.Detect(middleName));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("  ")]
        public void Should_throw_ArgumentNullException_if_middle_name_is_not_provided(string middleName)
        {
            Assert.Throws<ArgumentNullException>(() => GenderUtils.Detect(middleName));
        }
    }
}
