string GetSmallestString(string s)
{
    var letters = s.ToCharArray();
    for (int i = 1; i < letters.Length; i++)
    {
        if (letters[i] % 2 == letters[i - 1] % 2 && letters[i] < letters[i - 1])
        {
            (letters[i], letters[i - 1]) = (letters[i - 1], letters[i]);
            return string.Join("", letters);
        }
    }
    return s;
}