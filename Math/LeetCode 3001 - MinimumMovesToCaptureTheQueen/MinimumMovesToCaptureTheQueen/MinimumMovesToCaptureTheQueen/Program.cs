var a = 4;
var b = 5;
var c = 7;
var d = 8;
var e = 2;
var f = 3;
Console.WriteLine(MinMovesToCaptureTheQueen(a, b, c, d, e, f));

int MinMovesToCaptureTheQueen(int a, int b, int c, int d, int e, int f)
{
    if (a == e && b < f && (a != c || d < b || d > f))
        return 1;
    if (a == e && b > f && (a != c || d < f || d > b))
        return 1;
    if (b == f && a < e && (b != d || c < a || c > e))
        return 1;
    if (b == f && a > e && (b != d || c < e || c > a))
        return 1;
    if (e - c == f - d && e > c && (a - c != b - d || a < c || a > e))
        return 1;                        
    if (c - e == d - f && e < c && (a - e != b - f || a > e || a < c))
        return 1;                        
    if (c - e == f - d && e < c && (a - e != f - b || a < c || a > e))
        return 1;                        
    if (e - c == d - f && e > c && (e - a != b - f || a > e || a < c))
        return 1;
    return 2;
}