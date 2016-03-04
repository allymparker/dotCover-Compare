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
        public static List<Comparison> DoCompare(Root previous, Root current)
        {
            var previousC = previous.Items;
            var currentC = current.Items;
            return GetNamedCoverageDiffs(previousC, currentC);
        }

        private static List<Comparison> GetNamedCoverageDiffs(
            IEnumerable<NamedCoverageBase> previous,
            IEnumerable<NamedCoverageBase> current)
        {
            var assemblies = FullOuterJoin(previous, current);

            var matchingEntities =
                assemblies.Where(t => !Equals(t.Item1, t.Item2));

            var coverageDiffs =
                matchingEntities
                    .Select(t => DoCompare(t.Item1, t.Item2))
                    .ToList();
            return coverageDiffs.ToList();
        }

        private static Comparison DoCompare(NamedCoverageBase previous, NamedCoverageBase current)
        {
            var namedCoverageDiffs = new List<Comparison>();
            var previousCollection = previous as ICoverageCollection;
            if (previousCollection != null)
            {
                var currentCollection = current as ICoverageCollection;
                namedCoverageDiffs = GetNamedCoverageDiffs(previousCollection.Items ?? new NamedCoverageBase[0], currentCollection.Items?? new NamedCoverageBase[0]);
            }
            return new Comparison {Diff = new NamedCoverageDiff(previous, current), Items = namedCoverageDiffs};
        }

        public static IEnumerable<Tuple<NamedCoverageBase, NamedCoverageBase>> FullOuterJoin(
            IEnumerable<NamedCoverageBase> previous,
            IEnumerable<NamedCoverageBase> current)
        {
            var leftOuterJoin = LeftOuterJoin(previous, current);
            var rightOuterJoin = LeftOuterJoin(current, previous);

            return leftOuterJoin.Union(rightOuterJoin);
        }

        private static IEnumerable<Tuple<NamedCoverageBase, NamedCoverageBase>> LeftOuterJoin(IEnumerable<NamedCoverageBase> left, IEnumerable<NamedCoverageBase> right)
        {
            return left.GroupJoin(
                right,
                l => l.Name,
                r => r.Name,
                (l, temp) => new { l, temp})
                .SelectMany(
                    grp => grp.temp.DefaultIfEmpty(), 
                    (grp, r) => Tuple.Create(r, grp.l));
        }
    }
}