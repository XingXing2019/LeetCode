int[] nums1 = { 0, 3, 11, 12 };
int[] nums2 = { 5, 8, 6, 9 };
int k1 = 1, k2 = 300;
Console.WriteLine(MinSumSquareDiff(nums1, nums2, k1, k2));

long MinSumSquareDiff(int[] nums1, int[] nums2, int k1, int k2)
{
    var diff = new int[nums1.Length];
    for (int i = 0; i < nums1.Length; i++)
        diff[i] = Math.Abs(nums1[i] - nums2[i]);
    var dict = diff.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
    var maxHeap = new PriorityQueue<long[], long>();
    foreach (var num in dict.Keys)
        maxHeap.Enqueue(new long[]{num, dict[num]}, -num);
    long total = (long)k1 + k2, res = 0;
    while (total > 0 && maxHeap.Count != 0)
    {
        var cur = maxHeap.Dequeue();
        var curDiff = cur[0];
        var nextDiff = maxHeap.Count != 0 ? maxHeap.Peek()[0] : 0;
        if ((curDiff - nextDiff) * cur[1] <= total)
        {
            if (maxHeap.Count != 0)
                maxHeap.Peek()[1] += cur[1];
        }
        else
        {
            nextDiff = curDiff - 1;
            if ((curDiff - nextDiff) * cur[1] <= total)
                maxHeap.Enqueue(new []{cur[0] - 1, cur[1]}, -cur[0] + 1);
            else
            {
                maxHeap.Enqueue(new []{cur[0], cur[1] - total}, -cur[0]);
                maxHeap.Enqueue(new []{cur[0] - 1, total}, -cur[0] + 1);
            }
        }
        total -= (curDiff - nextDiff) * cur[1];
    }
    while (maxHeap.Count != 0)
    {
        var cur = maxHeap.Dequeue();
        res += cur[0] * cur[0] * cur[1];
    }
    return res;
}