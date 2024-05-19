using System.Net.WebSockets;

int[] nums = { 50, 28 };
Console.WriteLine(SumDigitDifferences(nums));

long SumDigitDifferences(int[] nums)
{
    var freqs = new int[10][];
    for (int i = 0; i < freqs.Length; i++)
        freqs[i] = new int[10];
    foreach (var num in nums)
    {
        int index = 0, copy = num;
        while (copy != 0)
        {
            freqs[index++][copy % 10]++;
            copy /= 10;
        }
    }
    var digits = new long[10];
    foreach (var num in nums)
    {
        int index = 0, copy = num;
        while (copy != 0)
        {
            digits[index] += GetSum(copy % 10, freqs[index++], nums.Length);
            copy /= 10;
        }
    }
    return digits.Sum(x => x / 2);
}

long GetSum(int digit, int[] freq, int count)
{
    var res = 0L;
    for (int i = 0; i < freq.Length; i++)
    {
        if (i == digit) continue;
        res += freq[i];
    }
    return res;
}