int[] nums = { 1, 2, 1 };
var k = 3;
int[][] edges = 
{
    new[] { 0, 1 },
    new[] { 0, 2 },
};
Console.WriteLine(MaximumValueSum(nums, k, edges));

long MaximumValueSum(int[] nums, int k, int[][] edges)
{
    var increases = new int[nums.Length];
    var sum = 0L;
    for (int i = 0; i < nums.Length; i++)
    {
        increases[i] = (nums[i] ^ k) - nums[i];
        sum += nums[i];
    }
    Array.Sort(increases, (a, b) => b - a);
    var count = increases.Length % 2 == 0 ? increases.Length : increases.Length - 1;
    var temp = 0L;
    for (int i = 0; i < count; i+=2)
    {
        if (temp + increases[i] + increases[i + 1] > temp)
            temp += increases[i] + increases[i + 1];
        else
            return sum + temp;
    }
    return sum + temp;
}