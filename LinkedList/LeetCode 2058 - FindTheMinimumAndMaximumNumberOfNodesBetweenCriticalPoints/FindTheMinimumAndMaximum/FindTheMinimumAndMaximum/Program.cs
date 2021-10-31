using System;

namespace FindTheMinimumAndMaximum
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
			var head = Generate(new[] {1, 3, 2, 2, 3, 2, 2, 2, 7});
			Console.WriteLine(NodesBetweenCriticalPoints(head));
		}

		public static int[] NodesBetweenCriticalPoints(ListNode head)
		{
			ListNode pre = head, cur = head.next;
			int first = int.MaxValue, last = -1, index = 1;
			int[] res = {int.MaxValue, int.MinValue};
			while (cur.next != null)
			{
				if (cur.val > pre.val && cur.val > cur.next.val || cur.val < pre.val && cur.val < cur.next.val)
				{
					first = Math.Min(first, index);
					if (last != -1)
						res[0] = Math.Min(res[0], index - last);
					last = index;
				}
				pre = pre.next;
				cur = cur.next;
				index++;
			}
			if (first == int.MaxValue || first == last)
				return new[] {-1, -1};
			res[1] = last - first;
			return res;
		}

		private static ListNode Generate(int[] nums)
		{
			ListNode res = null;
			for (int i = nums.Length - 1; i >= 0; i--)
				res = new ListNode(nums[i], res);
			return res;
		}
	}
}
