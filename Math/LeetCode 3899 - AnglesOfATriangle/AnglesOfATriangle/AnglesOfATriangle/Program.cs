int[] sides = { 3, 4, 5 };
Console.WriteLine(InternalAngles(sides));

double[] InternalAngles(int[] sides)
{
    Array.Sort(sides);
    if (sides[0] + sides[1] <= sides[2]) return Array.Empty<double>();
    var res = new double[3];
    for (int i = 0; i < 3; i++)
    {
        var a = sides[i];
        var b = i == 0 ? sides[1] : sides[0];
        var c = i == 2 ? sides[1] : sides[2];
        var cos = ((double)b * b + c * c - a * a) / (2 * b * c);
        res[i] = Math.Acos(cos) * (180 / Math.PI);
    }
    return res.OrderBy(x => x).ToArray();
}