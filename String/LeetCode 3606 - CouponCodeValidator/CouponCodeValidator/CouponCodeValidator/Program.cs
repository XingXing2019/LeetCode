IList<string> ValidateCoupons(string[] code, string[] businessLine, bool[] isActive)
{
    var coupons = new List<Coupon>();
    for (int i = 0; i < code.Length; i++)
        coupons.Add(new Coupon(code[i], businessLine[i], isActive[i]));
    return coupons.Where(x => x.IsValid()).OrderBy(x => x.Business).ThenBy(x => x.Code).Select(x => x.Code).ToList();
}

class Coupon : IComparable<Coupon>
{
    public string Code;
    public string Business;
    public bool IsActive;

    public Coupon(string code, string business, bool isActive)
    {
        Code = code;
        Business = business;
        IsActive = isActive;
    }

    public bool IsValid()
    {
        if (!IsActive) return false;
        var set = new HashSet<string> { "electronics", "grocery", "pharmacy", "restaurant" };
        if (!set.Contains(Business)) return false;
        return Code.All(l => char.IsLetter(l) || char.IsDigit(l) || l == '_') && Code != string.Empty;
    }

    public int CompareTo(Coupon? other)
    {
        var codeComparison = string.Compare(Business, other.Business, StringComparison.Ordinal);
        if (codeComparison != 0) return codeComparison;
        var businessComparison = string.Compare(Code, other.Code, StringComparison.Ordinal);
        if (businessComparison != 0) return businessComparison;
        return IsActive.CompareTo(other.IsActive);
    }
}