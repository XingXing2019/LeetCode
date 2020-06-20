//先将链表的每个节点值存入一个列表，删除连续和为0的数字后，再将列表转换会链表。
using System.Collections.Generic;
using System.Linq;

namespace RemoveZeroSum
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {2, -1, -1, 2, 1, -2};
            var head = GenerateLinkedList(nums);
            RemoveZeroSumSublists(head);
        }
        static ListNode RemoveZeroSumSublists(ListNode head)
        {
            var nums = new List<int>();
            while (head != null)
            {
                nums.Add(head.val);
                head = head.next;
            }
            var dict = new Dictionary<int, int>();
            dict[0] = -1;
            var deleteRange = new List<int[]>();
            int sum = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                sum += nums[i];
                if (dict.ContainsKey(sum)) 
                    deleteRange.Add(new[] { dict[sum] + 1, i });
                dict[sum] = i;
            }
            deleteRange = deleteRange.OrderBy(x => x[0]).ThenBy(x => x[1]).ToList();
            for (int i = 1; i < deleteRange.Count; i++)
                if (CheckOverLap(deleteRange[i], deleteRange[i - 1]))
                    deleteRange.RemoveAt(i--);
            var deletePos = new HashSet<int>();
            foreach (var range in deleteRange)
            {
                for (int i = range[0]; i <= range[1]; i++)
                    deletePos.Add(i);
            }
            ListNode res = null;
            for (int i = nums.Count - 1; i >= 0; i--)
            {
                if(deletePos.Contains(i)) continue;
                res = new ListNode(nums[i]) {next = res};
            }
            return res;
        }

        static bool CheckOverLap(int[] range1, int[] range2)
        {
            if (range1[0] <= range2[1] && range1[0] >= range2[0])
                return true;
            if (range2[0] <= range1[1] && range2[0] >= range1[0])
                return true;
            return false;
        }

        static ListNode GenerateLinkedList(int[] nums)
        {
            ListNode res = null;
            for (int i = nums.Length - 1; i >= 0; i--)
                res = new ListNode(nums[i]){next = res};
            return res;
        }
    }
}
