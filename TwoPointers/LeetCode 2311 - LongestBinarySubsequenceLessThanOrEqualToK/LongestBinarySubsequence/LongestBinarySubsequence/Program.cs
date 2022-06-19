var s = "11110100010101101010010";
var k = 9395105;

Console.WriteLine(LongestSubsequence(s, k));

int LongestSubsequence(string s, int k)
{
    int num = 0, res = s.Length, digits = 0;
    for (int i = s.Length - 1; i >= 0; i--)
    {
        if (s[i] == '0')
            digits++;
        else
        {
            if (digits > 32 || num + Math.Pow(2, digits) > k)
                res--;
            else
            {
                num += (int)Math.Pow(2, digits);
                digits++;
            }
        }
    }
    return res;
}