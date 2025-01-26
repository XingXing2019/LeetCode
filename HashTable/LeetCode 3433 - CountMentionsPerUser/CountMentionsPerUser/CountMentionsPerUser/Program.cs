int[] CountMentions(int numberOfUsers, IList<IList<string>> events)
{
    events = events.OrderBy(x => int.Parse(x[1])).ThenByDescending(x => x[0]).ToList();
    var offline = new int[numberOfUsers];
    var mentions = new int[numberOfUsers];
    Array.Fill(offline, int.MinValue);
    foreach (var e in events)
    {
        if (e[0] == "MESSAGE")
        {
            if (e[2] == "ALL")
            {
                for (int i = 0; i < numberOfUsers; i++)
                {
                    mentions[i]++;
                }
            }
            else if (e[2] == "HERE")
            {
                var time = int.Parse(e[1]);
                for (int i = 0; i < offline.Length; i++)
                {
                    if (offline[i] + 60 <= time)
                        mentions[i]++;
                }
            }
            else
            {
                var users = e[2].Split(" ").Select(x => int.Parse(x.Substring(2))).ToList();
                foreach (var user in users)
                {
                    mentions[user]++;
                }
            }
        }
        else
        {
            int time = int.Parse(e[1]), user = int.Parse(e[2]);
            offline[user] = time;
        }
    }
    return mentions;
}