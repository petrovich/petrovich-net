using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using RecycleBin.TextTables;

namespace NPetrovich.Eval.Data
{
    public static class CaseLoader
    {
        public static IEvalCase[] LoadCase(TextReader textReader)
        {
            using (var table = new FastCsvReader(textReader, new FastCsvReaderSettings()
            {
                FieldDelimiter = '\t'
            }))
            {
                table.HandleHeaderRow();
                return table.ReadToEnd<EvalCase>().ToArray<IEvalCase>();
            }
        }
    }
}