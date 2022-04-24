// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int CountLatticePoints(int[][] circles)
{
    var points = new HashSet<string>();
    foreach (var circle in circles)
        GetPoint(circle, points);
    return points.Count;
}

void GetPoint(int[] circle, HashSet<string> points)
{
    int x = circle[0], y = circle[1], r = circle[2];
    for (int i = circle[0] - r; i <= circle[0] + r; i++)
    {
        for (int j = circle[1] - r; j <= circle[1] + r; j++)
        {
            if ((i - x) * (i - x) + (j - y) * (j - y) <= r * r)
                points.Add($"{i}:{j}");
        }
    }
}