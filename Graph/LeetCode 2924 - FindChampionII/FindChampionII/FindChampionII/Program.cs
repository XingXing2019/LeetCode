var n = 2;
var edges = new int[][] { new int[] { 1, 0 } };
Console.WriteLine(FindChampion(n, edges));
int FindChampion(int n, int[][] edges)
{
    var inDegree = new int[n];
    foreach (var edge in edges)
        inDegree[edge[1]]++;
    var teams = inDegree.Where((i, x) => x == 0).Select((i, x) => i).ToList();
    return teams.Count != 1 ? -1 : teams.First();
}