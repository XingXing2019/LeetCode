//思路为使用滑动窗口维护一段字符串，找出这段字符串中出现最多字母的个数。
//如果个数加上k大于或等于这段字符串的长度，则证明窗口还可以扩大，则右端右移。否则窗口应当缩小，则左端右移。每次更新窗口的最大值。
//创建li和hi代表窗口的左右两端，让他们都指向字符串的第一个字母。创建一个长度为26的数组，记录每个字母出现的频率。手动将第一个字母的频率设为1.
//在hi不越界的条件下遍历。创建maxNum获取最高频字母的个数。如果这个个数加上k大于或等于窗口长度，则是hi右移，并在hi不越界的情况下将其指向字母的频率加一。
//否则先将li指向的字母频率减一，再使li右移。如果此时hi - li大于res则更新res。
using System;

namespace LongestRepeatingCharacterReplacement
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "AABABBA";
            int k = 1;
            Console.WriteLine(CharacterReplacement(s, k));
        }
        static int CharacterReplacement(string s, int k)
        {
            if (s.Length < 1)
                return 0;
            int res = 0;
            int li = 0;
            int hi = 0;
            int[] letters = new int[26];
            letters[s[0] - 'A']++;
            while (hi < s.Length)
            {
                int maxNum = 0;
                for (int i = 0; i < letters.Length; i++)
                    if (letters[i] > maxNum)
                        maxNum = letters[i];
                if (maxNum + k >= hi - li + 1)
                {
                    if (++hi < s.Length)
                        letters[s[hi] - 'A']++;
                }
                else
                    letters[s[li++] - 'A']--;
                if (hi - li > res)
                    res = hi - li;
            }
            return res;
        }
    }
}
