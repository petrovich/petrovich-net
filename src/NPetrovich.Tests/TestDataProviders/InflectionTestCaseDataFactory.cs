using System;
using System.Collections;
using System.IO;
using System.Linq;

namespace NPetrovich.Tests.TestDataProviders
{
    public class InflectionTestCaseDataFactory
    {
        public static IEnumerable LastNamesInflectionData
        {
            get
            {
                using (var reader = new StreamReader(Path.Combine("Data", "LastNames.csv")))
                {
                    foreach (var p in ReadCaseData(reader)) yield return p;
                }
            }
        }

        public static IEnumerable FirstNamesInflectionData
        {
            get
            {
                using (var reader = new StreamReader(Path.Combine("Data", "FirstNames.csv")))
                {
                    foreach (var p in ReadCaseData(reader)) yield return p;
                }
            }
        }

        public static IEnumerable MiddleNamesInflectionData
        {
            get
            {
                using (var reader = new StreamReader(Path.Combine("Data", "MiddleNames.csv")))
                {
                    foreach (var p in ReadCaseData(reader)) yield return p;
                }
            }
        }

        private static IEnumerable ReadCaseData(StreamReader reader)
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var chunks = line.Split(',').Select(s => s.Trim()).ToList();

                var gender = (Gender)Enum.Parse(typeof(Gender), chunks[1]);
                var @case = (Case)Enum.Parse(typeof(Case), chunks[2]);

                yield return new object[] { chunks[0], gender, @case, chunks[3] };
            }
        }

    }
}
