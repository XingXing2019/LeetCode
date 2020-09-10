using System;
using System.Collections.Generic;

namespace DesignCompressedStringIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new StringIterator("L1e2t1C1o1d1e1");
            Console.WriteLine(obj.Next());
            Console.WriteLine(obj.Next());
            Console.WriteLine(obj.Next());
            Console.WriteLine(obj.Next());
            Console.WriteLine(obj.Next());
            Console.WriteLine(obj.Next());
            Console.WriteLine(obj.HasNext());
            Console.WriteLine(obj.Next());
            Console.WriteLine(obj.HasNext());
        }
    }
    public class StringIterator
    {
        private List<char> letters;
        private List<long> nums;
        private int count;
        private int num;
        private int p1;
        private int p2;
        private int sum;
        public StringIterator(string compressedString)
        {
            letters = new List<char>();
            nums = new List<long>();
            foreach (var character in compressedString)
            {
                if (Char.IsLetter(character))
                {
                    letters.Add(character);
                    if (num != 0)
                        nums.Add(nums.Count == 0 ? num : num + nums[^1]);
                    sum += num;
                    num = 0;
                }
                else
                    num = num * 10 + (character - '0');
            }
            nums.Add(nums.Count == 0 ? num : num + nums[^1]);
            sum += num;
        }

        public char Next()
        {
            if (p2 >= nums.Count)
                return ' ';
            if (count >= nums[p2])
            {
                p1++;
                p2++;
            }
            count++;
            return p1 < letters.Count ? letters[p1] : ' ';
        }

        public bool HasNext()
        {
            return count < sum;
        }
    }
}
