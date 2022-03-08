using System;

namespace ReverseNodesInKGroup
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
			Console.WriteLine("Hello World!");
		}
		public ListNode ReverseKGroup(ListNode head, int k)
		{
			int len = 0;
			ListNode point = head, dummy = new ListNode(0, head);
			while (point != null)
			{
				len++;
				point = point.next;
			}
			point = dummy;
			for (int i = 0; i < len / k; i++)
			{
				for (int j = 0; j < k - 1; j++)
				{
					var next = head.next;
					head.next = next.next;
					next.next = point.next;
					point.next = next;
				}
				point = head;
				head = head.next;
			}
			return dummy.next;
		}
	}
}
