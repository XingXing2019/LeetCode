int CountBlocks(BigArray nums)
{
    long li = 0, len = nums.size();
    var res = 0;
    while (li < len)
    {
        li = BinarySearch(nums, li, len - 1);
        res++;
    }
    return res;
}

long BinarySearch(BigArray nums, long li, long hi)
{
    var target = nums.at(li);
    while (li <= hi)
    {
        var mid = li + (hi - li) / 2;
        if (nums.at(mid) == target)
            li = mid + 1;
        else
            hi = mid - 1;
    }
    return li;
}



class BigArray
{
    private readonly int[] _elements;
    public BigArray(int[] elements) { _elements = elements; }
    public int at(long index) => _elements[index];
    public long size() => _elements.Length;
}