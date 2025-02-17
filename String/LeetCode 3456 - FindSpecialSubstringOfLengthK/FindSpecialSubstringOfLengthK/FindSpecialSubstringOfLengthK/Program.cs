var s = "ccc";
var k = 2;
Console.WriteLine(HasSpecialSubstring(s, k));

bool HasSpecialSubstring(string s, int k)
{
    for (int i = 0; i <= s.Length - k; i++)
    {
        var letter = s[i];
        var isSame = true;
        for (int j = 0; j < k; j++)
        {
            if (s[i + j] == letter) continue;
            isSame = false;
            break;
        }
        var isBeforeDiff = i == 0 || s[i - 1] != letter;
        var isAfterDiff = i == s.Length - k || s[i + k] != letter;
        if (isBeforeDiff && isAfterDiff && isSame)
            return true;
    }
    return false;
}