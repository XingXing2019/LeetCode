var words = new List<string> { "1", "2", "prev", "prev", "prev" };
Console.WriteLine(LastVisitedIntegers(words));

IList<int> LastVisitedIntegers(IList<string> words)
{
    var nums = new List<int>();
    var res = new List<int>();
    var count = 0;
    foreach (var word in words)
    {
        if (word != "prev")
        {
            nums.Add(int.Parse(word));
            count = 0;
        }
        else
        {
            count++;
            res.Add(count > nums.Count ? -1 : nums[^count]);
        }
    }
    return res;
}