int[] nums = { 3 };
var s = "1";
Console.WriteLine(MaximumScore(nums, s));
long MaximumScore(int[] nums, string s)
{
    var res = 0L;
    var heap = new PriorityQueue<int, int>();
    for (int i = 0; i < nums.Length; i++)
    {
        heap.Enqueue(nums[i], -nums[i]);
        if (s[i] == '1')
        {
            res += heap.Dequeue();
        }
    }
    return res;
}