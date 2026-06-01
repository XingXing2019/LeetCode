int PasswordStrength(string password)
{
    var res = 0;
    var set = new HashSet<char>();
    foreach (var l in password)
    {
        if (!set.Add(l)) continue;
        if (l >= 'a' && l <= 'z')
            res++;
        else if (l >= 'A' && l <= 'Z')
            res += 2;
        else if (l >= '0' && l <= '9')
            res += 3;
        else
            res += 5;
    }
    return res;
}