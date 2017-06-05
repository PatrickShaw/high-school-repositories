using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithm___Prequisite__CSHARP_FOR_VB.NET_
{
    public static class Log2
    {
        static readonly ulong[] tab64 = new ulong[64] {
    63, 0, 58, 1, 59, 47, 53, 2,
    60, 39, 48, 27, 54, 33, 42, 3,
    61, 51, 37, 40, 49, 18, 28, 20,
    55, 30, 34, 11, 43, 14, 22, 4,
    62, 57, 46, 52, 38, 26, 32, 41,
    50, 36, 17, 19, 29, 10, 13, 21,
    56, 45, 25, 31, 35, 16, 9, 12,
    44, 24, 15, 8, 23, 7, 6, 5};
        public static ulong log2_64(ulong value)
        {
            value = value | value >> 1;
            value = value | value >> 2;
            value = value | value >> 4;
            value = value | value >> 8;
            value = value | value >> 16;
            value = value | value >> 32;
            return tab64[(((value - (value >> 1)) * 0x07EDD5E59A4E28C2) >> 58)];
        }
    }
}
