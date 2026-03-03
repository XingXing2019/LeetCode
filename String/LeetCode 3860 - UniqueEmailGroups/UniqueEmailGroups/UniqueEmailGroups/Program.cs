int UniqueEmailGroups(string[] emails)
{
    var set = new HashSet<string>(emails.Select(Normalize));
    return set.Count;
}

string Normalize(string email)
{
    var parts = email.Split('@');
    var index = parts[0].IndexOf('+');
    if (index != -1)
        parts[0] = parts[0].Substring(0, index);
    return parts[0].Replace(".", "").ToLower() + parts[1].ToLower();
}