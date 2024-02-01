using System.Globalization;

namespace NPetrovich.Eval.Data;

public class EvalCase : IEvalCase
{
    private string _lemma;
    private string _grammem;
    private string _word;
    private static readonly TextInfo CultureTextInfo = Thread.CurrentThread.CurrentCulture.TextInfo;

    public string Grammemes
    {
        get => _grammem;
        set
        {
            _grammem = CultureTextInfo.ToLower(value);
            var splitted = value.Split(',');
            if (splitted.Length != 3) throw new ArgumentException();
            Gender = GrammemesParser.ParseGender(splitted[0]);
            Case = GrammemesParser.ParseCase(splitted[2]);
        }
    }

    public string Lemma
    {
        get => _lemma;
        set => _lemma = CultureTextInfo.ToLower(value);
    }

    public string Word
    {
        get => _word;
        set => _word = CultureTextInfo.ToLower(value);
    }

    public Gender Gender { get; set; }
    public Case Case { get; set; }

    public string Result { get; set; }

    public override string ToString()
    {
        return $"{Lemma} {Word} {Gender} {Case} - {Result}";
    }
}