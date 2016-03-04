using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using dotCoverCompare.XmlModel;
using NUnit.Framework;

namespace dotCoverCompare.Tests.Unit
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            var xmlSerializer = new XmlSerializer(typeof(Root));
            var current = (Root)xmlSerializer.Deserialize(XmlReader.Create(new StringReader(DotCoverResults.case1Current)));
            var previous = (Root)xmlSerializer.Deserialize(XmlReader.Create(new StringReader(DotCoverResults.case1Previous)));

            var namedCoverageDiffs = Compare.DoCompare(previous, current);

            foreach (var diff in namedCoverageDiffs)
            {
                Console.WriteLine($"{(diff.CoveragePercentDiff < 0 ?"Decrease":"Increase")} by {Math.Abs(diff.CoveragePercentDiff):P} in {diff.Name}");
            }
        }
    }
}
