using System;
using System.Collections.Generic;
using System.Linq;

namespace PeopleWhoseList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IList<string>> favoriteCompanies = new List<IList<string>>
            {
                new List<string>
                {
                    "nxaqhyoprhlhvhyojanr", "ovqdyfqmlpxapbjwtssm", "qmsbphxzmnvflrwyvxlc", "udfuxjdxkxwqnqvgjjsp",
                    "yawoixzhsdkaaauramvg", "zycidpyopumzgdpamnty"
                },
                new List<string>
                {
                    "nxaqhyoprhlhvhyojanr", "ovqdyfqmlpxapbjwtssm", "udfuxjdxkxwqnqvgjjsp", "yawoixzhsdkaaauramvg",
                    "zycidpyopumzgdpamnty"
                },
                new List<string>
                {
                    "ovqdyfqmlpxapbjwtssm", "qmsbphxzmnvflrwyvxlc", "udfuxjdxkxwqnqvgjjsp", "yawoixzhsdkaaauramvg",
                    "zycidpyopumzgdpamnty"
                }
            };
            Console.WriteLine(PeopleIndexes(favoriteCompanies));
        }
        static IList<int> PeopleIndexes(IList<IList<string>> favoriteCompanies)
        {
            var record = new HashSet<string>[favoriteCompanies.Count];
            for (int i = 0; i < favoriteCompanies.Count; i++)
                record[i] = new HashSet<string>(favoriteCompanies[i]);
            var res= new List<int>();
            for (int i = 0; i < record.Length; i++)
            {
                var isSubset = false;
                for (int j = 0; j < record.Length; j++)
                {
                    if(i == j || record[i].Count >= record[j].Count)
                        continue;
                    var containsAll = true;
                    foreach (var company in record[i])
                    {
                        if (!record[j].Contains(company))
                        {
                            containsAll = false;
                            break;
                        }
                    }
                    if (containsAll)
                    {
                        isSubset = true;
                        break;
                    }
                }   
                if(!isSubset)
                    res.Add(i);
            }
            return res;
        }
    }

}
