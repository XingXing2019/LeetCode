using System;

namespace MergeInBetweenLinkedLists
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var list1 = Generate(new[] {0, 1, 2, 3, 4, 5});
            var list2 = Generate(new[] {1000000, 1000001, 1000002});
            int a = 2, b = 3;
            Console.WriteLine(MergeInBetween(list1, a, b, list2));
        }

        static ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2)
        {
            var res = list1;
            while (list1 != null)
            {
                var pre = list1;
                list1 = list1.next;
                a--;
                b--;
                if (a == 0)
                {
                    pre.next = list2;
                    while (list2.next != null)
                        list2 = list2.next;
                }
                if (b == 0)
                {
                    list2.next = list1.next;
                    break;
                }
            }
            return res;
        }

        static ListNode Generate(int[] nums)
        {
            ListNode res = null;
            for (int i = nums.Length - 1; i >= 0; i--)
                res = new ListNode(nums[i], res);
            return res;
        }
    }
}
