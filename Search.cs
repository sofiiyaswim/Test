using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sueta
{
    public static class Search
    {
        public static int LinearSearch(string SubValue, string Value)
        {
            int result = -1;//Если вхождение подстроки не найдено
            for (int i = 0; i < Value.Length - SubValue.Length + 1; i++)
            {
                for (int j = 0; j < SubValue.Length; j++)
                {
                    if (SubValue[j] != Value[i + j])
                    {
                        break;
                    }
                    else if (j == SubValue.Length - 1)
                    {
                        return i;
                    }
                }
            }
            return result;
        }

        public static int BMSearch(string SubValue, string Value)
        {
            int sl, ssl;
            int result = -1;
            sl = Value.Length;
            ssl = SubValue.Length;

            int i, Pos;
            int[] BMT = new int[256];
            for (i = 0; i < 256; i++)
                BMT[i] = ssl;
            for (i = ssl - 1; i >= 0; i--)
                if (BMT[(short)(SubValue[i])] == ssl)
                    BMT[(short)(SubValue[i])] = ssl - i - 1;
            Pos = ssl - 1;
            while (Pos < sl)
                if (SubValue[ssl - 1] != Value[Pos])
                    Pos = Pos + BMT[(short)(Value[Pos])];
                else
                    for (i = ssl - 2; i >= 0; i--)
                    {
                        if (SubValue[i] != Value[Pos - ssl + i + 1])
                        {
                            Pos += BMT[(short)(Value[Pos - ssl + i + 1])] - 1;
                            break;
                        }
                        else
                          if (i == 0)
                            return Pos - ssl + 1;
                    }
            return result;
        }

        public static int KMPSearch(string SubValue, string Value)
        {
           
            int[] pf = GetPrefix(SubValue);
            int index = 0;

            for (int i = 0; i < Value.Length; i++)
            {
                while (index > 0 && SubValue[index] != Value[i])
                {
                    index = pf[index - 1];
                }
                if (SubValue[index] == Value[i]) index++;
                if (index == SubValue.Length)
                {
                    return i - index + 1;
                }
            }
            return -1;
        }

        public static int[] GetPrefix(string s)
        {
            int[] result = new int[s.Length];
            result[0] = 0;
            int index = 0;

            for (int i = 1; i < s.Length; i++)
            {
                while (index >= 0 && s[index] != s[i]) { index--; }
                index++;
                result[i] = index;
            }

            return result;
        }
    }
}
