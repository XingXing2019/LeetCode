int[] nums1 = { 1, 1, 2 };
int[] nums2 = { 2, 1, 1 };
Console.WriteLine(MinSplitMerge(nums1, nums2));

int MinSplitMerge(int[] nums1, int[] nums2)
{
    var start = string.Join(":", nums1);
    var target = string.Join(":", nums2);
    var queue = new Queue<Tuple<string, int>>();
    queue.Enqueue(new Tuple<string, int>(start, 0));
    var visited = new HashSet<string> { start };
    while (queue.Count != 0)
    {
        var cur = queue.Dequeue();
        var curStr = cur.Item1;
        var curCount = cur.Item2;
        if (curStr == target)
            return curCount;
        var curArr = curStr.Split(':');
        for (int i = 0; i < curArr.Length; i++)
        {
            for (int j = i; j < curArr.Length; j++)
            {
                var removed = curArr[i..(j + 1)];
                var left = curArr[..i].Concat(curArr[(j + 1)..]).ToArray();
                for (int k = 0; k <= left.Length; k++)
                {
                    var nextArr = left[0..k].Concat(removed).Concat(left[k..]).ToArray();
                    var nextStr = string.Join(":", nextArr);
                    if (!visited.Add(nextStr)) continue;
                    queue.Enqueue(new Tuple<string, int>(nextStr, curCount + 1));
                }
            }
        }
    }
    return -1;
}