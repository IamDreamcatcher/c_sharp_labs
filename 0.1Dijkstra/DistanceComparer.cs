using System;
using System.Collections.Generic;

namespace Dijkstra
{
    public class DistanceComparer : IComparer<Tuple<int, City>>
    {
        public int Compare(Tuple<int, City> x, Tuple<int, City> y)
        {
            if (x.Item1 < y.Item1) return -1;
            if (x.Item1 > y.Item1) return 1;
            return x.Item2.name.CompareTo(y.Item2.name);
        }
    }
}
