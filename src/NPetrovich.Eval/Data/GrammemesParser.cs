namespace NPetrovich.Eval.Data;

static class GrammemesParser
{
    public static Gender ParseGender(string str)
    {
        switch (str)
        {
            case "мр":
                return Gender.Male;
            case "жр":
                return Gender.Female;
            case "мр-жр":
                return Gender.Androgynous;
            default:
                throw new ArgumentException(nameof(str));
        }
    }

    public static Case ParseCase(string str)
    {
        switch (str)
        {
            case "им":
                return Case.Nominative;
            case "рд":
                return Case.Genitive;
            case "дт":
                return Case.Dative;
            case "вн":
                return Case.Accusative;
            case "тв":
                return Case.Instrumental;
            case "пр":
                return Case.Prepositional;
            default:
                throw new ArgumentException(nameof(str));
        }
    }
}