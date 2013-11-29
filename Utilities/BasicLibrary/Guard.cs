using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLibrary
{
    public class Guard
    {
        public static void IsNotNull(object o)
        {
            if (o == null)
            {
                throw new Exception("the object can not be null.");
            }
        }

        public static void ArrayLengthEqual(Array array, int length)
        {
            if (array.Length != length)
            {
                throw new Exception(string.Format("the length of the array isn't equal to the expected value {0}", length));
            }
        }

        public static void ArrayLengthGreatThanOrEqual(Array array, int length)
        {
            if (array.Length < length)
            {
                throw new Exception(string.Format("the length of the array should be greater than or equals the expected value {0}", length));
            }
        }

        public static void IsNotEqual(int value1, int value2)
        {
            if (value1 == value2)
            {
                throw new Exception(string.Format("the two are expected not be equal, but they are {0} and {1} respectively", value1, value2));
            }
        }
        public static void IsEqual(int value1, int value2)
        {
            if (value1 != value2)
            {
                throw new Exception(string.Format("the two are expected be equal, but they are {0} and {1} respectively", value1, value2));
            }
        }

        public static void IsEqual(int value1, int value2, int value3)
        {
            Guard.IsEqual(value1, value2);
            Guard.IsEqual(value2, value3);
        }
        public static void IsEqual(int value1, int value2, int value3, int value4)
        {
            Guard.IsEqual(value1, value2);
            Guard.IsEqual(value2, value3);
            Guard.IsEqual(value3, value4);
        }

        public static void Increase<T>(T[] arr, int step, Func<T, int> valueRetriever)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (valueRetriever(arr[i]) + step != valueRetriever(arr[i + 1]))
                {
                    throw new Exception(string.Format("the array is not increased by degrees {0}", step));
                }
            }
        }
    }
}
