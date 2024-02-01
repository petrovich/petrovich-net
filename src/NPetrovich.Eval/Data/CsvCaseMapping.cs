using TinyCsvParser.Mapping;

namespace NPetrovich.Eval.Data;

public class CsvCaseMapping : CsvMapping<EvalCase>
{
    public CsvCaseMapping()
    {
        MapProperty(0, x => x.Lemma);
        MapProperty(1, x => x.Word);
        MapProperty(2, x => x.Grammemes);
    }
}