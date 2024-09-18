var a = "a";
var b = "ayza";
Console.WriteLine(MinCharacters(a, b));

int MinCharacters(string a, string b)
{
    var res = int.MaxValue;
    for (int i = 0; i < 26; i++)
        res = Math.Min(res, CountChanges(a, b, (char)(i + 'a')));
    return res;
}

int CountChanges(string a, string b, char l)
{
    var res = a.Count(x => x != l) + b.Count(x => x != l);
    if (l != 'z')
    {
        res = Math.Min(res, Count(a, b, l));
        res = Math.Min(res, Count(b, a, l));
    }
    return res;
}

int Count(string a, string b, char l)
{
    var res = 0;
    foreach (var c in a)
    {
        if (c <= l) continue;
        res++;
    }
    foreach (var c in b)
    {
        if (c > l) continue;
        res++;
    }
    return res;
}