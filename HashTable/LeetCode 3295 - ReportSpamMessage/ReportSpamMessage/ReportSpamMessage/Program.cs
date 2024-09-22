bool ReportSpam(string[] message, string[] bannedWords)
{
    var banned = new HashSet<string>(bannedWords);
    var count = message.Count(x => banned.Contains(x));
    return count > 1;
}