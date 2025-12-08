var s = "hello";
Console.WriteLine(MaxSameLengthRuns(s));

int MaxSameLengthRuns(string s)
{
    var dict = new Dictionary<int, int>();
    int count = 0, max = 0;
    var letter = s[0];
    foreach (var l in s)
    {
        if (l == letter)
            count++;
        else
        {
            if (!dict.ContainsKey(count))
                dict[count] = 0;
            dict[count]++;
            max = Math.Max(max, dict[count]);
            letter = l;
            count = 1;
        }
    }
    return Math.Max(max, dict.GetValueOrDefault(count, 0) + 1);
}