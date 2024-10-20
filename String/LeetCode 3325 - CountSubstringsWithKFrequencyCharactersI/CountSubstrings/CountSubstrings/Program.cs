var s = "abacb";
var k = 2;
Console.WriteLine(NumberOfSubstrings(s, k));

int NumberOfSubstrings(string s, int k)
{
    var res = 0;
    for (int i = 0; i < s.Length; i++)
    {
        var freq = new int[26];
        for (int j = i; j < s.Length; j++)
        {
            freq[s[j] - 'a']++;
            if (freq[s[j] - 'a'] == k)
            {
                res += s.Length - j;
                break;
            }
        }
    }
    return res;
}