var s1 = "m";
var s2 = "amh";
Console.WriteLine(ShortestSuperstring(s1, s2));

string ShortestSuperstring(string s1, string s2)
{
    var str1 = FindString(s1, s2);
    var str2 = FindString(s2, s1);
    return str1.Length < str2.Length ? str1 : str2;
}

string FindString(string s1, string s2)
{
    if (s1.Length == 1)
        return s2.Contains(s1) ? s2 : s1 + s2;
    var len = 0;
    for (int i = s1.Length - 1; i >= 0; i--)
    {
        var str = s1.Substring(i);
        if (s2.StartsWith(str)) 
            len = s1.Length - i;
    }
    return s1 + s2.Substring(len);
}