using System.Diagnostics;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace NPetrovich.Tests.Bindings
{
    [Binding]
    public class PetrovichBindings
    {
        [Given(@"I have list of names, genders and expected inflections")]
        public void GivenIHaveListOfNamesGendersAndExpectedInflections(Table table)
        {
            var data = table.Rows.Select(
                row =>
                new Tuple<string, Gender, Case, string>(
                    row[0], 
                    (Gender) Enum.Parse(typeof (Gender), row[1]),
                    (Case) Enum.Parse(typeof (Case), 
                    row[2]), 
                    row[3]));

            ScenarioContext.Current.Set(data, "data");
        }

        [When(@"I try to inflect names")]
        public void WhenITryToInflectNames()
        {
            var data = ScenarioContext.Current.Get<IEnumerable<Tuple<string, Gender, Case, string>>>("data");
            var results = new List<Tuple<string, string>>();
            foreach (var row in data)
            {
                var names = row.Item1.Split(' ');
                var petrovich  = new Petrovich {LastName = names[0], FirstName = names[1], MiddleName = names[2], Gender = row.Item2};
                petrovich.InflectTo(row.Item3);
                results.Add(new Tuple<string, string>(row.Item4, petrovich.ToString()));
            }

            ScenarioContext.Current.Set(results);
        }

        [Then(@"the result should be correct")]
        public void ThenTheResultShouldBeCorrect()
        {
            var results = ScenarioContext.Current.Get<List<Tuple<string, string>>>();
            foreach (var result in results)
            {
                Trace.WriteLine(string.Format("Expected: {0}, Actual {1}", result.Item1, result.Item2));
                Assert.AreEqual(result.Item1, result.Item2);
            }
        }
    }
}
