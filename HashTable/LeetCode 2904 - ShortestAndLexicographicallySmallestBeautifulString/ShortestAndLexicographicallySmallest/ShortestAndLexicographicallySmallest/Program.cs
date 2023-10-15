var s = "1100100101011001001";
var k = 7;
Console.WriteLine(ShortestBeautifulSubstring(s, k));

string ShortestBeautifulSubstring(string s, int k)
{
    var res = s + s;
    var dict = new Dictionary<int, int> { {0, -1} };
    var ones = 0;
    for (int i = 0; i < s.Length; i++)
    {
        if (s[i] == '1')
        {
            ones++;
            if (dict.ContainsKey(ones - k))
            {
                int left = dict[ones - k] + 1, len = i - left + 1;
                var temp = s.Substring(left, len);
                if (temp.Length < res.Length || temp.Length == res.Length && temp.CompareTo(res) < 0)
                    res = temp;
            }
        }
        dict[ones] = i;
    }
    return res == s + s ? "" : res;
}