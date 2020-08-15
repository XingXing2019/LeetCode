//需要尽量把较小的数字放在前面。所以遇到I时，就计算他前面有n个D，然后把n+1个数字倒叙记入结果。
//可以在s后面人家加入一个I，确保最后一次插入成功。
//用num来记录当前应该插入的数字。再循环中，注意控制一下num。
using System;

namespace FindPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "IDDIIDID";
            Console.WriteLine(FindPermutation(s));
        }
        static int[] FindPermutation(string s)
        {
            var res = new int[s.Length + 1];
            int countD = 0, num = 0, index = 0;
            s += 'I';
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'D')
                    countD++;
                else if(s[i] == 'I')
                {
                    num += countD + 1;
                    for (int j = 0; j < countD + 1; j++)
                        res[index++] = num--;
                    num += countD + 1;
                    countD = 0;
                }
            }
            return res;
        }
    }
}
