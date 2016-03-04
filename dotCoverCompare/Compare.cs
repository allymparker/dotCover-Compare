using System;
using System.Collections.Generic;
using System.Linq;
using dotCoverCompare.Domain;
using dotCoverCompare.XmlModel;

namespace dotCoverCompare
{
    public class Compare
    {
        //this is flawed as assemblies/classes/types can change name... Would need to do some kind of code diff against git to find matching members...
        public static List<NamedCoverageDiff> DoCompare(Root previous, Root current)
        {
            var previousC = previous.Items;
            var currentC = current.Items;
            return GetNamedCoverageDiffs(previousC, currentC);
        }

        private static List<NamedCoverageDiff> GetNamedCoverageDiffs(NamedCoverageBase[] previousC, NamedCoverageBase[] currentC)
        {
            var assemblies =
                previousC.Join(
                    currentC,
                    a => a.Name,
                    a => a.Name,
                    Tuple.Create).ToList();
            var newEntity = assemblies.Where(t => t.Item1 == null).ToList();

            var matchingEntities =
                assemblies.Where(t => t.Item1 != null && t.Item2 != null && !Equals(t.Item1, t.Item2))
                    .Select(t => new NamedCoverageDiff(t.Item1, t.Item2))
                    .ToList();

            return matchingEntities.ToList();
        }
    }
}