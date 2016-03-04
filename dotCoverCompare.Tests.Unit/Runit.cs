using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using dotCoverCompare.Domain;
using dotCoverCompare.XmlModel;
using NUnit.Framework;

namespace dotCoverCompare.Tests.Unit
{
    [TestFixture]
    public class Runit
    {
        [Test]
        public void TestMethod1()
        {
            var xmlSerializer = new XmlSerializer(typeof(Root));
            var current = (Root)xmlSerializer.Deserialize(XmlReader.Create(new StringReader(DotCoverResults.case1Current)));
            var previous = (Root)xmlSerializer.Deserialize(XmlReader.Create(new StringReader(DotCoverResults.case1Previous)));

            var namedCoverageDiffs = Compare.DoCompare(previous, current);

            Print(namedCoverageDiffs);
        }

        private static void Print(IEnumerable<Comparison> namedCoverageDiffs, string indent="")
        {
            foreach (var result in namedCoverageDiffs)
            {
                switch (result.Diff.PercentChange)
                {
                    case CoverageChange.Increased:
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;
                    case CoverageChange.Unchanged:
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        break;
                    case CoverageChange.Decreased:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                Console.WriteLine($"{indent}{result.Diff.PercentChange} " +
                                  $"by {Math.Abs(result.Diff.CoveragePercentDiff):P} " +
                                  $"to {result.Diff.CurrentCoveragePercent:P} " +
                                  $"in {result.Diff.Name} - " +
                                  $"Total Statements {result.Diff.TotalStatementChange}");

                if (result.Items.Any())
                {
                    Print(result.Items, indent + "-");
                    Console.WriteLine();
                }
            }
        }
    }
}
