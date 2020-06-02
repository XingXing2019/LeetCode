//使用二分搜索方法，但需要注意，先判断target是否超出边界，超出边界则直接返回第一个元素。
using System;

namespace FindSmallestLetterGreaterThanTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] letters = { 'c', 'f', 'j' };
            char target = 'k';
            Console.WriteLine(NextGreatestLetter(letters, target));
        }
        static char NextGreatestLetter(char[] letters, char target)
        {
            if (target >= letters[letters.Length - 1])
                return letters[0];
            int li = 0;
            int hi = letters.Length - 1;
            while (li < hi)
            {
                int mid = li + (hi - li) / 2;
                if (letters[mid] > target)
                    hi = mid;
                else
                    li = mid + 1;
            }
            return letters[li];
        }
    }
}
