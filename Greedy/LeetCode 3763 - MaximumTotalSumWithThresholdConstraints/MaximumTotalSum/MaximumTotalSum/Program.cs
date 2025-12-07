int[] nums = { 1, 10, 4, 2, 1, 6 };
int[] threshold = { 5, 1, 5, 5, 2, 2 };
Console.WriteLine(MaxSum(nums, threshold));

long MaxSum(int[] nums, int[] threshold)
{
    var items = new List<int[]>();
    for (int i = 0; i < nums.Length; i++)
        items.Add(new[] { nums[i], threshold[i] });
    items = items.OrderBy(x => x[1]).ThenByDescending(x => x[0]).ToList();
    long res = 0, step = 1;
    foreach (var item in items)
    {
        if (item[1] <= step)
        {
            res += item[0];
            step++;
        }
        else
            return res;
    }
    return res;
}