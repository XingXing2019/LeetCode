var s = "uo";
var k = 5;
Console.WriteLine(GetSmallestString(s, k));

string GetSmallestString(string s, int k)
{
    var res = "";
    foreach (var l in s)
    {
        if (k == 0)
            res += l;
        else
        {
            var decrease = Math.Min(l - 'a', k);
            var decreaseL = (char)(l - decrease);
            var increase = Math.Min('z' - l + 1, k);
            var increaseL = l + increase > 'z' ? (char)((l + increase) % 'z' + 'a' - 1) : (char)(l + increase);
            if (decreaseL < increaseL)
            {
                k -= decrease;
                res += decreaseL;
            }
            else if (decreaseL > increaseL)
            {
                k -= increase;
                res += increaseL;
            }
            else
            {
                k -= Math.Min(increase, decrease);
                res += increaseL;
            }
        }
    }
    return res;
}