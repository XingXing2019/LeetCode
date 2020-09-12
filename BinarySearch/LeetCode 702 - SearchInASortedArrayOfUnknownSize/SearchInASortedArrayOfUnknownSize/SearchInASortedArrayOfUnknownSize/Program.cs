using System;

namespace SearchInASortedArrayOfUnknownSize
{
    class ArrayReader
    {
        private readonly int[] _nums;

        public ArrayReader(int[] nums)
        {
            _nums = nums;
        }

        public int Get(int index)
        {
            return index < _nums.Length ? _nums[index] : -1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new ArrayReader(new[] {-1, 0, 3, 5, 9, 12});
            int target = 2;
            Console.WriteLine(Search(reader, target));
        }
        static int Search(ArrayReader reader, int target)
        {
            int li = 0, hi = 10000;
            while (li < hi)
            {
                int mid = li + (hi - li) / 2;
                int num = reader.Get(mid);
                if (num == target)
                    return mid;
                if (num > target || num == -1)
                    hi = mid;
                else
                    li = mid + 1;
            }
            return reader.Get(li) == target ? li : -1;
        }
    }
}
