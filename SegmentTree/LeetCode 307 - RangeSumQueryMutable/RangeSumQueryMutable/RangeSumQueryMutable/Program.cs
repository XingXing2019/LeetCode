using System;
using System.Security.Cryptography;

namespace RangeSumQueryMutable
{
	class Program
	{
		static void Main(string[] args)
		{
			var numArray = new NumArray(new[] {1, 3, 5});
			Console.WriteLine(numArray.SumRange(0, 2));
			numArray.Update(1, 2);
			Console.WriteLine(numArray.SumRange(0, 2));
		}
	}

	public class SegmentTreeNode
	{
		public int sum;
		public int start;
		public int end;
		public SegmentTreeNode left;
		public SegmentTreeNode right;
		public SegmentTreeNode(int start, int end, int sum, SegmentTreeNode left = null, SegmentTreeNode right = null)
		{
			this.sum = sum;
			this.start = start;
			this.end = end;
			this.left = left;
			this.right = right;
		}
	}

	public class NumArray
	{
		private SegmentTreeNode root;
		public NumArray(int[] nums)
		{
			root = Build(nums, 0, nums.Length - 1);
		}

		private SegmentTreeNode Build(int[] nums, int start, int end)
		{
			if (start == end)
				return new SegmentTreeNode(start, end, nums[start]);
			var mid = start + (end - start) / 2;
			var left = Build(nums, start, mid);
			var right = Build(nums, mid + 1, end);
			return new SegmentTreeNode(start, end, left.sum + right.sum, left, right);
		}

		public void Update(int index, int val, SegmentTreeNode root = null)
		{
			if (root == null) root = this.root;
			if (root.start == root.end && root.start == index)
			{
				root.sum = val;
				return;
			}
			int mid = root.start + (root.end - root.start) / 2;
			Update(index, val, index <= mid ? root.left : root.right);
			root.sum = root.left.sum + root.right.sum;
		}

		public int SumRange(int left, int right, SegmentTreeNode root = null)
		{
			if (root == null) root = this.root;
			if (root.start == left && root.end == right)
				return root.sum;
			int mid = root.start + (root.end - root.start) / 2;
			if (right <= mid)
				return SumRange(left, right, root.left);
			if (left > mid)
				return SumRange(left, right, root.right);
			return SumRange(left, mid, root.left) + SumRange(mid + 1, right, root.right);
		}
	}
}
