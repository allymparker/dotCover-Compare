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
            var assemblies =
                previous.Assembly.Join(
                    current.Assembly,
                    a => a.Name,
                    a => a.Name,
                    Tuple.Create).ToList();
            var newAssemblies = assemblies.Where(t => t.Item1 == null).ToList();

            var matchingAssemblies =
                assemblies.Where(t => t.Item1 != null && t.Item2 != null && !Equals(t.Item1, t.Item2))
                .Select(t => new NamedCoverageDiff(t.Item1, t.Item2))
                    .ToList();

            return matchingAssemblies.ToList();
        }
    }
}