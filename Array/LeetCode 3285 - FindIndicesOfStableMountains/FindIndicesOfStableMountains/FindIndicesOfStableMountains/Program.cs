IList<int> StableMountains(int[] height, int threshold)
{
    var res = new List<int>();
    for (int i = 1; i < height.Length; i++)
    {
        if (height[i - 1] <= threshold) continue;
        res.Add(i);
    }
    return res;
}