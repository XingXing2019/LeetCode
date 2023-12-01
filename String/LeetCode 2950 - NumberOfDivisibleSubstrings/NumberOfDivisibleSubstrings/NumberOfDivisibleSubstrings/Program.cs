var word = "asdf";
Console.WriteLine(CountDivisibleSubstrings(word));

int CountDivisibleSubstrings(string word)
{
    int[] map = {1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 6, 7, 7, 7, 8, 8, 8, 9, 9, 9};
    var prefix = new int[word.Length];
    var res = 0;
    for (int i = 0; i < word.Length; i++)
        prefix[i] = i == 0 ? map[word[i] - 'a'] : map[word[i] - 'a'] + prefix[i - 1];
    for (int i = 0; i < word.Length; i++)
    {
        for (int j = i; j < word.Length; j++)
        {
            if (!IsDivisible(prefix, i, j)) continue;
            res++;
        }
    }
    return res;
}

bool IsDivisible(int[] prefix, int li, int hi)
{
    int sum = li == 0 ? prefix[hi] : prefix[hi] - prefix[li - 1], len = hi - li + 1;
    return sum % len == 0;
}