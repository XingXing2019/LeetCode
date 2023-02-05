int[] VowelStrings(string[] words, int[][] queries)
{
    var counts = new int[words.Length];
	var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
	for (int i = 0; i < words.Length; i++)
	{
		counts[i] = i == 0 ? 0 : counts[i - 1];
		if (!vowels.Contains(words[i][0]) || !vowels.Contains(words[i][^1])) continue;
		counts[i]++;
	}
	var res = new int[queries.Length];
	for (int i = 0; i < queries.Length; i++)
		res[i] = counts[queries[i][1]] - (queries[i][0] == 0 ? 0 : counts[queries[i][0] - 1]);
	return res;
}