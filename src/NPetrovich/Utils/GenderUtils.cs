using System.Globalization;

namespace NPetrovich.Utils
{
    public static class GenderUtils
    {
        public static Gender Detect(string middleName)
        {
            Guard.IfArgumentNullOrWhitespace(middleName, "middleName", "You must specify middle name to detect gender");

            if (middleName.EndsWith("оглы", true, CultureInfo.InvariantCulture))
                return Gender.Male;

            if (middleName.EndsWith("кызы", true, CultureInfo.InvariantCulture))
                return Gender.Female;

            if (middleName.EndsWith("ич", true, CultureInfo.InvariantCulture))
                return Gender.Male;

            if (middleName.EndsWith("на", true, CultureInfo.InvariantCulture))
                return Gender.Female;

            return Gender.Androgynous;
        }
    }
}
