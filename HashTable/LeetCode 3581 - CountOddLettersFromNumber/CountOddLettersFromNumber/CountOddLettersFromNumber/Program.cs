int CountOddLetters(int n)
{
    string[] nums = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
    var freq = new Dictionary<char, int>();
    while (n != 0)
    {
        var num = nums[n % 10];
        foreach (var l in num)
        {
            if (!freq.ContainsKey(l))
                freq[l] = 0;
            freq[l]++;
        }
        n /= 10;
    }
    return freq.Where(x => x.Value % 2 != 0).ToList().Count;
}