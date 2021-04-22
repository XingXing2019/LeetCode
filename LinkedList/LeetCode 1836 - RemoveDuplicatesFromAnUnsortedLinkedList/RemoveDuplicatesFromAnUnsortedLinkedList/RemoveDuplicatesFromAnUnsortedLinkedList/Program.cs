using System;
using System.Collections.Generic;

namespace RemoveDuplicatesFromAnUnsortedLinkedList
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
* }
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public ListNode DeleteDuplicatesUnsorted(ListNode head)
		{
			var dict = new Dictionary<int, int>();
			ListNode point = head, dummy = new ListNode(0, head), pre = dummy;
			while (point != null)
			{
				if (!dict.ContainsKey(point.val))
					dict[point.val] = 0;
				dict[point.val]++;
				point = point.next;
			}
			while (head != null)
			{
				if (dict[head.val] == 1)
				{
					pre.next = head;
					pre = pre.next;
				}
				head = head.next;
			}
			pre.next = head;
			return dummy.next;
		}
	}
}
