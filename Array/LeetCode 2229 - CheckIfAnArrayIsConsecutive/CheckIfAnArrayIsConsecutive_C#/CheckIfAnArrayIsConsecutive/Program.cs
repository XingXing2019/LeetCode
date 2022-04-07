// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

bool IsConsecutive(int[] nums)
{
    var record = new bool[nums.Length];
    var min = nums.Min();
    foreach (var num in nums)
    {
        if (num - min >= record.Length) return false;
        if (record[num - min]) return false;
        record[num - min] = true;
    }
    return record.All(x => x);
}