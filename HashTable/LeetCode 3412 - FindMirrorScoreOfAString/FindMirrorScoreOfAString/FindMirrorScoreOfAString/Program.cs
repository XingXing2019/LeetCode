var s = "aczzx";
Console.WriteLine(CalculateScore(s));

long CalculateScore(string s)
{
    var dict = new Dictionary<char, Stack<int>>();
	var res = 0L;
	for (int i = 0; i < s.Length; i++)
	{
        if (!dict.ContainsKey(s[i]))
            dict[s[i]] = new Stack<int>();
        var mirror = (char)(25 - s[i] + 'a' + 'a');
		if (dict.ContainsKey(mirror) && dict[mirror].Count != 0)
			res += i - dict[mirror].Pop();
		else         
            dict[s[i]].Push(i);
    }
	return res;
}