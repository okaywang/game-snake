using System;
using System.Collections.Generic;
using System.Text;

namespace CommonHelper
{
    public class Helper
    {
        /// <summary>
        /// for example:
        /// 0 1 0 0
        /// 1 1 1 0
        /// 0 0 0 0
        /// ------->
        /// 0 1 0
        /// 0 1 1
        /// 0 1 0
        /// 0 0 0
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool[,] ClockwiseRotate90(bool[,] data)
        {
            var rowBound = data.GetUpperBound(0);
            var colBound = data.GetUpperBound(1);
            var result = new bool[colBound + 1, rowBound + 1];
            for (int i = 0; i <= rowBound; i++)
            {
                for (int j = 0; j <= colBound; j++)
                {
                    result[j, rowBound - i] = data[i, j];
                }
            }
            return result;
        }
    }
}
