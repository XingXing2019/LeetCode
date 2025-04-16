int FindClosest(int x, int y, int z)
{
    int dis1 = Math.Abs(x - z), dis2 = Math.Abs(y - z);
    return dis1 == dis2 ? 0 : dis1 < dis2 ? 1 : 2;
}