int[] nums = { 9, 4, 9 };
Console.WriteLine(TriangleType(nums));

string TriangleType(int[] nums)
{
    Array.Sort(nums);
    if (nums[0] + nums[1] <= nums[2])
        return "none";
    if (nums.All(x => x == nums[0]))
        return "equilateral";
    if (nums[0] == nums[1] || nums[1] == nums[2])
        return "isosceles";
    return "scalene";
}