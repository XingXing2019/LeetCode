IList<int> ToggleLightBulbs(IList<int> bulbs)
{
    return bulbs.GroupBy(x => x).Where(x => x.Count() % 2 != 0).Select(x => x.Key).OrderBy(x => x).ToList();
}