int sx = 9, sy = 5, tx = 12, ty = 8;
Console.WriteLine(ReachingPoints(sx, sy, tx, ty));


bool ReachingPoints(int sx, int sy, int tx, int ty)
{
    if (sx == tx && sy == ty) return true;
    if (sx > tx || sy > ty) return false;
    if (tx == ty) return tx == sx && ty == sy;
    if (tx > ty)
    {
        var n = (tx - sx) / ty == 0 ? 1 : (tx - sx) / ty;
        return ReachingPoints(sx, sy, tx - n * ty, ty);
    }
    else
    {
        var n = (ty - sy) / tx == 0 ? 1 : (ty - sy) / tx;
        return ReachingPoints(sx, sy, tx, ty - n * tx);
    }
}