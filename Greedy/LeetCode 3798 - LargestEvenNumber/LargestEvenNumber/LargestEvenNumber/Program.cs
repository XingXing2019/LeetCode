string LargestEven(string s)
{
    var pos = s.LastIndexOf('2');
    return s.Substring(0, pos + 1);
}