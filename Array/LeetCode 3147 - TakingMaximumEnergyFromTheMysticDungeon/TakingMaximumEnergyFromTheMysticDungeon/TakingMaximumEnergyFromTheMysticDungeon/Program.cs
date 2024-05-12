int MaximumEnergy(int[] energy, int k)
{
    for (int i = 0; i < energy.Length; i++)
        energy[i] += i - k >= 0 ? energy[i - k] : 0;
    var res = int.MinValue;
    for (int i = 0; i < energy.Length; i++)
    {
        var pre = i - k >= 0 ? energy[i - k] : 0;
        var index = (energy.Length - i) % k == 0 ? ((energy.Length - i) / k - 1) * k + i : (energy.Length - i) / k * k + i;
        var post = energy[index];
        res = Math.Max(res, post - pre);
    }
    return res;
}