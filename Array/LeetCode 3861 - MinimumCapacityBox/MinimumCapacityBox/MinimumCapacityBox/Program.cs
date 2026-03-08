int MinimumIndex(int[] capacity, int itemSize)
{
    int size = int.MaxValue, index = -1;
    for (int i = 0; i < capacity.Length; i++)
    {
        if (capacity[i] < itemSize) continue;
        if (capacity[i] < size)
        {
            size = capacity[i];
            index = i;
        }
    }
    return index;
}