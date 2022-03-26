//使用二分搜索。创建li和hi指针指向数组首尾，在li小于hi的条件下遍历数组，遍历时创建mid指针指向li和hi中点。
//如果mid指向数字大于target则使hi等于mid，如果小于在使li指向mid+1。如果等于则返回mid。遍历结束后检查li指向数字是否为target，如果是返回li。否则数组中没有target返回-1.
using System;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int Search(int[] nums, int target)
        {
            int li = 0;
            int hi = nums.Length - 1;
            while (li < hi)
            {
                int mid = li + (hi - li) / 2;
                if (nums[mid] > target)
                    hi = mid;
                else if (nums[mid] < target)
                    li = mid + 1;
                else
                    return mid;
            }
            if (nums[li] == target)
                return li;
            return -1;
        }
    }
}
