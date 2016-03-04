using System.Collections.Generic;
using dotCoverCompare.Domain;

namespace dotCoverCompare
{
    public class Comparison
    {
        public NamedCoverageDiff Diff { get; set; }
        public IEnumerable<Comparison> Items { get; set; }
    }
}