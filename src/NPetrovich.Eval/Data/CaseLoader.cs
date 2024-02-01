using System.Text;
using TinyCsvParser;

namespace NPetrovich.Eval.Data;

public static class CaseLoader
{
    public static IEvalCase[] LoadCase(Stream stream)
    {
        var csvParserOptions = new CsvParserOptions(true, '\t');
        var csvMapper = new CsvCaseMapping();
        var csvParser = new CsvParser<EvalCase>(csvParserOptions, csvMapper);

        return csvParser
            .ReadFromStream(stream, Encoding.UTF8).Select(r => r.Result).ToArray<IEvalCase>();
    }
}