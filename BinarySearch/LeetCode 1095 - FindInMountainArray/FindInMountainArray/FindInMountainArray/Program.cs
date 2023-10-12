var mountainArr = new MountainArray(new[] { 3, 5, 3, 2, 0 });
var target = 0;
Console.WriteLine(FindInMountainArray(target, mountainArr));

int FindInMountainArray(int target, MountainArray mountainArr)
{
    var peak = FindPeak(mountainArr);
    var left = SearchLeft(mountainArr, peak, target);
    if (left != -1)
        return left;
    return SearchRight(mountainArr, peak, target);
}

int FindPeak(MountainArray mountainArr)
{
    int li = 0, hi = mountainArr.Length() - 1;
    while (li < hi)
    {
        var mid = li + (hi - li) / 2;
        int right = mountainArr.Get(mid + 1), value = mountainArr.Get(mid);
        if (value < right)
            li = mid + 1;
        else
            hi = mid - 1;
    }
    return li;
}

int SearchLeft(MountainArray mountainArr, int peak, int target)
{
    int li = 0, hi = peak;
    while (li <= hi)
    {
        var mid = li + (hi - li) / 2;
        var value = mountainArr.Get(mid);
        if (value == target)
            return mid;
        if (value < target)
            li = mid + 1;
        else
            hi = mid - 1;
    }
    return -1;
}

int SearchRight(MountainArray mountainArr, int peak, int target)
{
    int li = peak, hi = mountainArr.Length() - 1;
    while (li <= hi)
    {
        var mid = li + (hi - li) / 2;
        var value = mountainArr.Get(mid);
        if (value == target)
            return mid;
        if (value < target)
            hi = mid - 1;
        else
            li = mid + 1;
    }
    return -1;
}

class MountainArray
{
    private readonly int[] _array;

    public MountainArray(int[] array)
    {
        _array = array;
    }

    public int Get(int index)
    {
        return _array[index];
    }

    public int Length()
    {
        return _array.Length;
    }
}