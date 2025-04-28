var n = 3;
var buildings = new int[][]
{
    new[] { 1, 2 },
    new[] { 2, 2 },
    new[] { 3, 2 },
    new[] { 2, 1 },
    new[] { 2, 3 },
};
Console.WriteLine(CountCoveredBuildings(n, buildings));

int CountCoveredBuildings(int n, int[][] buildings)
{
    buildings = buildings.OrderBy(x => x[0]).ThenBy(x => x[1]).ToArray();
    var xDict = new Dictionary<int, List<int>>();
    foreach (var building in buildings)
    {
        int x = building[0], y = building[1];
        if (!xDict.ContainsKey(x))
            xDict[x] = new List<int>();
        xDict[x].Add(y);
    }
    buildings = buildings.OrderBy(x => x[1]).ThenBy(x => x[0]).ToArray();
    var yDict = new Dictionary<int, List<int>>();
    foreach (var building in buildings)
    {
        int x = building[0], y = building[1];
        if (!yDict.ContainsKey(y))
            yDict[y] = new List<int>();
        yDict[y].Add(x);
    }
    var res = 0;
    foreach (var building in buildings)
    {
        int x = building[0], y = building[1];
        var xPos = yDict[y];
        var yPos = xDict[x];
        if (x != xPos[0] && x != xPos[^1] && y != yPos[0] && y != yPos[^1])
        {
            res++;
        }
    }
    return res;
}