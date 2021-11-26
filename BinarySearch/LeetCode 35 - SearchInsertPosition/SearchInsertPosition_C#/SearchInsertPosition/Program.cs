﻿//遍历数组，如果当前元素大于或等于target，则直接返回当前i指针。(由于数组值排好序的，如果遍历到第一个大于target的元素，则就应该在该点插入target)
//如果遍历结束后还没有返回，那么数组中所有元素都小于target，则要在数组最后插入target，所以返回nums.Length。
using System;

namespace SearchInsertPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 3, 5, 6 };
            int target = 0;
           
        }
        static int SearchInsert_BruceForce(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= target)
                    return i;
            }
            return nums.Length;
        }
        static int SearchInsert_BuildingInBinarySearch(int[] nums, int target)
        {
            var index = Array.BinarySearch(nums, target);
            return index < 0 ? -(index + 1) : index;
        }
        static int SearchInsert_BinarySearch(int[] nums, int target)
        {
            if (nums.Length == 1)
                return nums[0] >= target ? 0 : 1;
            int li = 0, hi = nums.Length - 1;
            while (li < hi)
            {
                int mid = li + (hi - li) / 2;
                if (nums[mid] == target) return mid;
                if (nums[mid] > target)
                    hi = mid;
                else
                    li = mid + 1;
            }
            return nums[li] >= target ? li : li + 1;
        }
    }
}
