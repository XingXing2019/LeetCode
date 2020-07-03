//创建original记录nums，copy复制nums。
//打乱数组时，遍历copy。让每一位与随机生成的index上的数字交换。
using System;

namespace ShuffleAnArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class Solution
    {
        private readonly int[] _origin;
        private readonly int[] _copy;
        private Random _random;

        public Solution(int[] nums)
        {
            _origin = nums;
            _copy = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
                _copy[i] = nums[i];
            _random = new Random();
        }

        /** Resets the array to its original configuration and return it. */
        public int[] Reset()
        {
            return _origin;
        }

        /** Returns a random shuffling of the array. */
        public int[] Shuffle()
        {
            var shuffle = new int[_origin.Length];
            for (int i = 0; i < _copy.Length; i++)
            {
                var index = _random.Next(_copy.Length);
                var temp = _copy[i];
                _copy[i] = _copy[index];
                _copy[index] = temp;
            }
            return _copy;
        }
    }
}
