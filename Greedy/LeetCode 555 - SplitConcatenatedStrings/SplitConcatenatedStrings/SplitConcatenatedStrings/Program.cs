string[] strs = { "ab", "xy", "cd", "aaa", "bab" };
Console.WriteLine(SplitLoopedString(strs));

string SplitLoopedString(string[] strs)
{
    var largest = new string[strs.Length];
    var res = string.Join("", strs);
    for (int i = 0; i < strs.Length; i++)
    {
        var reversed = string.Join("", strs[i].Reverse());
        largest[i] = Compare(strs[i], reversed) < 0 ? reversed : strs[i];
    }
    for (int i = 0; i < strs.Length; i++)
    {
        var front = string.Join("", largest[..i]);
        var after = string.Join("", largest[(i + 1)..]);
        var reversed = string.Join("", strs[i].Reverse());
        for (int j = 0; j < strs[i].Length; j++)
        {
            var str1 = strs[i].Substring(j);
            var str2 = reversed.Substring(j);
            var word = Compare(str1, str2) < 0
                ? str2 + after + front + reversed.Substring(0, j)
                : str1 + after + front + strs[i].Substring(0, j);
            if (Compare(res, word) < 0)
                res = word;
        }   
    }
    return res;
}

int Compare(string str1, string str2)
{
    if (str1 == str2) return 0;
    for (int i = 0; i < str1.Length; i++)
    {
        if (str1[i] < str2[i])
            return -1;
        if (str1[i] > str2[i])
            return 1;
    }
    return 0;
}