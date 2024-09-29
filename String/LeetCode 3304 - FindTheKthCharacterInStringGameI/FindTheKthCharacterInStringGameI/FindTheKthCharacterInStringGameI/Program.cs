var k = 5;
Console.WriteLine(KthCharacter(k));

char KthCharacter(int k)
{
    var s = "a";
    while (s.Length < k)
    {
        var temp = "";
        foreach (var l in s)
            temp += l == 'z' ? 'a' : (char)(l + 1);
        s += temp;
    }
    return s[k - 1];
}