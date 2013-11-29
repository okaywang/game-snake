using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLibrary
{
    public class Identifier
    {
        public static bool BeSameRespectively<T, TItem>(List<T> items, Func<T, TItem> func, TItem item1, TItem item2) where TItem : IComparable<TItem>
        {
            if (items.Count != 2)
            {
                return false;
            }

            return func(items[0]).CompareTo(item1) == 0 && func(items[1]).CompareTo(item2) == 0;
        }

        public static bool BeSame<T, TItem>(List<T> items1, List<T> items2, Func<T, TItem> func) where TItem : IComparable<TItem>
        {
            if (items1.Count != items2.Count)
            {
                return false;
            }
            for (int i = 0; i < items1.Count; i++)
            {
                if (func(items1[i]).CompareTo(func(items2[i])) != 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool BeSame<T, TItem>(List<T> items, Func<T, TItem> func) where TItem : IComparable<TItem>
        {
            return BeSame(items, 0, items.Count, func);
        }

        public static bool BeSame<T, TItem>(List<T> items, int fromIndex, int count, Func<T, TItem> func) where TItem : IComparable<TItem>
        {
            var endIndex = fromIndex + count - 1;
            for (int i = fromIndex; i < endIndex; i++)
            {
                if (func(items[i]).CompareTo(func(items[i + 1])) != 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool Increase<T>(IList<T> arr, int step, Func<T, int> valueRetriever)
        {
            for (int i = 0; i < arr.Count - 1; i++)
            {
                if (valueRetriever(arr[i]) + step != valueRetriever(arr[i + 1]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
