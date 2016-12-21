using System;
using System.Globalization;
using System.Threading;
using RecycleBin.TextTables;

namespace NPetrovich.Eval.Data
{
    internal class EvalCase : IEvalCase
    {
        private string _lemma;
        private string _word;
        private static readonly TextInfo CultureTextInfo = Thread.CurrentThread.CurrentCulture.TextInfo;

        [Column("grammemes")]
        public string Grammemes
        {
            set
            {
                var splitted = value.Split(',');
                if (splitted.Length != 3) throw new ArgumentException();
                Gender = GrammemesParser.ParseGender(splitted[0]);
                Case = GrammemesParser.ParseCase(splitted[2]);
            }
        }

        [Column("lemma")]
        public string Lemma
        {
            get { return _lemma; }
            set { _lemma = CultureTextInfo.ToLower(value); }
        }

        [Column("word")]
        public string Word
        {
            get { return _word; }
            set { _word = CultureTextInfo.ToLower(value); }
        }

        public Gender Gender { get; set; }
        public Case Case { get; set; }

        public string Result { get; set; }

        public override string ToString()
        {
            return $"{Lemma} {Word} {Gender} {Case} - {Result}";
        }
    }
}