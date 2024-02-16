string[] words = { "a", "a", "caa" };
Console.WriteLine(MaxPalindromesAfterOperations(words));

int MaxPalindromesAfterOperations(string[] words)
{
    var freq = new int[26];
    foreach (var word in words)
    {
        foreach (var l in word)
        {
            freq[l - 'a']++;
        }
    }
    int odd = 0, even = 0, res = 0;
    foreach (var f in freq)
    {
        even += f % 2 == 0 ? f : f - 1;
        odd += f % 2 == 0 ? 0 : 1;
    }
    words = words.OrderBy(x => x.Length).ToArray();
    foreach (var word in words)
    {
        if (word.Length % 2 == 0 && even >= word.Length)
        {
            res++;
            even -= word.Length;
        }
        else if (word.Length % 2 != 0)
        {
            if (odd > 0 && even >= word.Length - 1)
            {
                res++;
                odd--;
                even -= word.Length - 1;
            }
            else if (even >= word.Length)
            {
                res++;
                even -= word.Length;
            }
        }
    }
    return res;
}