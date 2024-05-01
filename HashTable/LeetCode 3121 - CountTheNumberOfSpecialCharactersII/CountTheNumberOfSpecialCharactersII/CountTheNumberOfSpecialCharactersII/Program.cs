var word = "aaAbcBC";
Console.WriteLine(NumberOfSpecialChars(word));

int NumberOfSpecialChars(string word)
{
    var firstUpper = new int[26];
    var lastLower = new int[26];
    Array.Fill(firstUpper, -1);
    Array.Fill(lastLower, -1);
    for (int i = 0; i < word.Length; i++)
    {
        if (char.IsLower(word[i]))
            lastLower[word[i] - 'a'] = i;
        if (char.IsUpper(word[^(i + 1)]))
            firstUpper[word[^(i + 1)] - 'A'] = word.Length - i - 1;
    }
    var res = 0;
    for (int i = 0; i < 26; i++)
    {
        if (firstUpper[i] == -1 || lastLower[i] == -1 || firstUpper[i] < lastLower[i]) continue;
        res++;
    }
    return res;
}