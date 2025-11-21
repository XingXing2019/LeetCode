var s = "hello world";
var k = 17;
Console.WriteLine(KthCharacter(s, k));

char KthCharacter(string s, long k)
{
    var words = s.Split(' ');
    foreach (var word in words)
    {
        for (int i = 0; i < word.Length; i++)
        {
            k -= i + 1;
            if (k < 0) return word[i];
        }
        if (k == 0)
            return ' ';
        k--;
    }
    return ' ';
}