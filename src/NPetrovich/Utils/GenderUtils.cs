using NPetrovich.GenderDetermination;

namespace NPetrovich.Utils
{
    public static class GenderUtils
    {
        public static readonly GenderDeterminator Determinator = new GenderDeterminator();

        public static Gender Detect(string middleName)
        {
            Guard.IfArgumentNullOrWhitespace(middleName, "middleName", "You must specify middle name to detect gender");

            return Determinator.Determinate(new Petrovich
            {
                MiddleName = middleName
            });
        }
    }
}
