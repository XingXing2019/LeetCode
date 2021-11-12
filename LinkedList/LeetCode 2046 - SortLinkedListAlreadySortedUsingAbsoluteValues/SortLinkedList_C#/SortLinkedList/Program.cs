using System;
using System.ComponentModel;

namespace SortLinkedList
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
			var head = Generate(new[] {0, 2, -5, 5, 10, -10});
			Console.WriteLine(SortLinkedList(head));
		}

		public static ListNode SortLinkedList(ListNode head)
		{
			ListNode posHead = new ListNode(), posPointer = posHead;
			ListNode negHead = new ListNode(), negPointer = negHead;
			while (head != null)
			{
				if (head.val >= 0)
				{
					posPointer.next = new ListNode(head.val);
					posPointer = posPointer.next;
				}
				else
				{
					var temp = new ListNode(head.val, negHead.next);
					negHead.next = temp;
				}
				head = head.next;
			}
			posPointer.next = null;
			while (negPointer.next != null) 
				negPointer = negPointer.next;
			negPointer.next = posHead.next;
			return negHead.next;
		}

		public static ListNode Generate(int[] nums)
		{
			ListNode res = null;
			for (int i = nums.Length - 1; i >= 0; i--)
				res = new ListNode(nums[i], res);
			return res;
		}
	}
}
