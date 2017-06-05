using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Library__CSHARP____Crappy_Number_Compression
{
    public static class PSCompressor
    {
        public static long[] ReadCompressed(string word)
        {
            string[] split = word.Split('!');
            // Note: First number will always be the actual value of the integer
            // 2 splits: Eg. 0!100= {0 To 100}
            // 3 splits: Eg. 3!4! = {3,3,3,3,3}
            long value = FromHex(split[0]);
            switch(split.Count())
            {
                case 1:
                    return new long[]{value};
                case 2:
                    long endNumber = FromHex(split[1]);
                    long[] numbers01 = new long[endNumber - value];
                    for (int i =0;i<numbers01.Count();i++)
                    {
                        numbers01[i] = value + i;
                    }
                    return numbers01;
                case 3:
                    long repeats = FromHex(split[1]);
                    long[] numbers02 = new long[repeats+ 1];
                    for (int i = 0; i <= repeats;i++ )
                    {
                        numbers02[i] = value;
                    }
                    return numbers02;
            }
            return null;
        }
        public static long FromHex(string sT)
        {
            return long.Parse(sT, System.Globalization.NumberStyles.HexNumber );
        }
        public static long[] ByteReader(string path)
        {
            List<long> numbers = new List<long>();

            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                long restCount = reader.ReadInt64() ;
                for (int i = 0; i < restCount; i++)
                {
                    numbers.Add(reader.ReadInt64());
                }
            }
            return numbers.ToArray();

        }
        public static void ByteWriter(long[] lA,string path)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path,FileMode.Create)))
            {
                writer.Write((long)lA.Count());
                for(int i = 0; i < lA.Count();i++)
                {

                    writer.Write(lA[i]);
            
                }
            }
        }
        public static List<string> Compress(long[] lA)
        {
            List<string> sL = new List<string>();
            int lpoint = -1;
            begin:
            lpoint += 1;
            if (lpoint >= lA.Count()) { return sL; }
            // Read as compression
            if(lpoint + 1 < lA.Count())
            {
                if (lA[lpoint] == lA[lpoint+1])
                {
                    int repeats = 1;
                repeatBegin:
                    lpoint += 1;
                    if (lpoint + 1 < lA.Count())
                    {
                    if (lA[lpoint] == lA[lpoint+1])
                    {
                    repeats += 1;
                        goto repeatBegin;
                    }
                    }
                    sL.Add(lA[lpoint].ToString("X")+"!" + repeats.ToString("X") + "!");
                    goto begin;
                }
                if (lA[lpoint] == lA[lpoint+1] - 1)
                {
                    long low = lA[lpoint];
                    long high = lA[lpoint + 1];
                rangeBegin:
                    lpoint += 1;
                    if (lpoint + 1 < lA.Count())
                        if (lA[lpoint] == lA[lpoint + 1] - 1)
                        {
                            high = lA[lpoint + 1];
                            goto rangeBegin;
                        }
                    sL.Add(low.ToString("X")+"!"+high.ToString("X"));
                    goto begin;
                }
            }
            // or else just don't lel.
            sL.Add(lA[lpoint].ToString("X"));
            goto begin;
        }
    }
}
