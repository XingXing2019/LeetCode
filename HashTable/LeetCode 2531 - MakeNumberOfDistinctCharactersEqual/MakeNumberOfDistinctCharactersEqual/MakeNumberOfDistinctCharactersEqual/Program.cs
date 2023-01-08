string word1 = "a", word2 = "bb";
Console.WriteLine(IsItPossible(word1, word2));

bool IsItPossible(string word1, string word2)
{
    int[] freq1 = new int[26], freq2 = new int[26];
    foreach (var l in word1)
        freq1[l - 'a']++;
    foreach (var l in word2)
        freq2[l - 'a']++;
    for (int i = 0; i < 26; i++)
    {
        if (freq1[i] == 0) continue;
        freq1[i]--;
        freq2[i]++;
        for (int j = 0; j < 26; j++)
        {
            if (freq2[j] == 0 || freq2[j] == 1 && i == j) continue;
            freq2[j]--;
            freq1[j]++;
            if (freq1.Count(x => x != 0) == freq2.Count(x => x != 0))
                return true;
            freq1[j]--;
            freq2[j]++;
        }
        freq2[i]--;
        freq1[i]++;
    }
    return false;
}