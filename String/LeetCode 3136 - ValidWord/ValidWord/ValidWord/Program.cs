var word = "AhI";
Console.WriteLine(IsValid(word));

bool IsValid(string word)
{
    if (word.Length < 3) return false;
    var vowel = new HashSet<int> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
    bool hasVowel = false, hasConsonant = false;
    foreach (var l in word)
    {
        if (!char.IsDigit(l) && !char.IsLetter(l))
            return false;
        if (vowel.Contains(l))
            hasVowel = true;
        else if (char.IsLetter(l) && !vowel.Contains(l))
            hasConsonant = true;
    }
    return hasVowel && hasConsonant;
}