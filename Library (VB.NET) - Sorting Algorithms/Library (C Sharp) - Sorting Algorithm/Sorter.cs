using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Library__C_Sharp____Sorting_Algorithm
{
    public static class CSharpSorter
    {
        public static List<T> Sort<T>(List<T> list) where T : IComparable
        {
            if (list.Count <= 1) return list;
            List<T> left = list.GetRange(0, list.Count / 2);
            List<T> right = list.GetRange(left.Count, list.Count - left.Count);
            return Merge(Sort(left), Sort(right));
        }

        public static List<T> Merge<T>(List<T> left, List<T> right) where T : IComparable
        {
            List<T> result = new List<T>();
            // 
            while (left.Count > 0 && right.Count > 0)
            {
                if (left[0].CompareTo(right[0]) <= 0)
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
            }
            result.AddRange(left);
            result.AddRange(right);
            return result;
        }
    }
}
