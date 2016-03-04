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

            var namedCoverageDiffs = new Compare(false).DoCompare(previous, current);

            Print(namedCoverageDiffs);
        }

        private static void Print(IEnumerable<Comparison> comparisons, string indent="")
        {
            foreach (var comparison in comparisons.OrderBy(r=>r.Diff.Name))
            {
                var diff = comparison.Diff;
                switch (diff.CoverageChangeType)
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

                Console.WriteLine($"{indent}{diff.CoverageType.Name} {diff.CoverageChangeType} " +
                                  $"by {Math.Abs(diff.CoveragePercentDiff):P} " +
                                  $"to {diff.CurrentCoveragePercent:P} " +
                                  $"in {diff.Name} - " +
                                  $" {diff.StatementChangeType}");

                if (comparison.Items.Any())
                {
                    Print(comparison.Items, indent + "-");
                    Console.WriteLine();
                }
            }
        }
    }
}
