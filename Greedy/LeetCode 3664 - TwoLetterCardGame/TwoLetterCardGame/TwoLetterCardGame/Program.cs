string[] cards = { "ab", "ab", "bc", "bc", "bb", "bc", "bc", "ba", "bc", "cb", "ba", "bb", "cb", "cb", "cb", "ba", "bc", "ba", "bb", "ba", "bb", "ba", "bb" };
var x = 'b';
Console.WriteLine(Score(cards, x));

int Score(string[] cards, char x)
{
    var first = new Dictionary<string, int>();
    var second = new Dictionary<string, int>();
    var both = 0;
    foreach (var card in cards)
    {
        if (card[0] == x && card[1] == x)
            both++;
        else if (card[0] == x)
            first[card] = first.GetValueOrDefault(card, 0) + 1;
        else if (card[1] == x)
            second[card] = second.GetValueOrDefault(card, 0) + 1;
    }
    var firstCount = Count(first);
    var secondCount = Count(second);
    return firstCount[0] + secondCount[0] + Math.Min(both, firstCount[1] + secondCount[1]);
}

int[] Count(Dictionary<string, int> cards)
{
    var freq = cards.Select(x => x.Value).ToArray();
    var res = 0;
    for (int i = 0; i < freq.Length; i++)
    {
        for (int j = i + 1; j < freq.Length; j++)
        {
            if (freq[j] == 0) continue;
            var pairs = Math.Min(freq[i], freq[j]);
            res += pairs;
            freq[i] -= pairs;
            freq[j] -= pairs;
        }
    }
    return new[] {res, freq.Sum()};
}