using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLibrary
{
    public class Miscellanea
    {
        public static int[] GetUnrepeatableRandom(int count)
        {
            var data = new int[count];
            var tracks = new bool[count];
            var rnd = new Random();

            int invalidCount = 0;
            while (invalidCount < count)
            {
                var rndNum = rnd.Next(0, count);
                if (tracks[rndNum])
                {
                    continue;
                }
                tracks[rndNum] = true;
                data[invalidCount] = rndNum;
                invalidCount++;
            }
            return data;
        }
    }
}
