using System.Globalization;

namespace NPetrovich.Utils
{
    public static class GenderUtils
    {
        private const string ExceptionMessage = "You must specify middle name to detect gender";
        private const string ParameterName = "middleName";

        public static Gender Detect(string middleName)
        {
            Guard.IfArgumentNullOrWhitespace(middleName, ParameterName, ExceptionMessage);

            if (middleName.EndsWith("ич", true, CultureInfo.InvariantCulture))
                return Gender.Male;

            if (middleName.EndsWith("на", true, CultureInfo.InvariantCulture))
                return Gender.Female;

            return Gender.Androgynous;
        }

        public static Gender DetectGender(string middleName)
        {
            Guard.IfArgumentNullOrWhitespace(middleName, ParameterName, ExceptionMessage);

            return Detect(middleName);
        }
    }
}
