using System.Collections.Generic;
using System.Linq;

namespace PokeHealRank
{
    static class MergeSorting
    {
        public static List<HealItem> Sort(List<HealItem> unsorted) => MergeSort(unsorted).ToArray().Reverse().ToList();

        static List<HealItem> MergeSort(List<HealItem> u)
        {
            if (u.Count < 2)
                return u;

            List<HealItem> l = new List<HealItem>();
            List<HealItem> r = new List<HealItem>();
            int m = u.Count / 2;

            for (int i = 0; i < m; i++)
                l.Add(u[i]);

            for (int i = m; i < u.Count; i++)
                r.Add(u[i]);

            l = MergeSort(l);
            r = MergeSort(r);
            return Merge(l, r);
        }

        static List<HealItem> Merge(List<HealItem> l, List<HealItem> r)
        {
            List<HealItem> res = new List<HealItem>();

            while (l.Count > 0 || r.Count > 0)
            {
                if (l.Count > 0 && r.Count > 0)
                {
                    if (l.First().hpp <= r.First().hpp)
                    {
                        res.Add(l.First());
                        l.Remove(l.First());
                    }
                    else
                    {
                        res.Add(r.First());
                        r.Remove(r.First());
                    }
                }
                else if (l.Count > 0)
                {
                    res.Add(l.First());
                    l.Remove(l.First());
                }
                else if (r.Count > 0)
                {
                    res.Add(r.First());
                    r.Remove(r.First());
                }
            }
            return res;
        }
    }
}
