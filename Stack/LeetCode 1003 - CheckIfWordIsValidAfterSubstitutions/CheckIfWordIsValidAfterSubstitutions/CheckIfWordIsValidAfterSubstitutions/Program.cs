//利用StringBuilder型record操作S中的字母。如果遇到a或b则将其加入record尾部。
//遇到c则判断record最后两个字母是否为ab，如果是则将最后两个字母删除，否则将c加入。最后返回record是否为空。
using System;
using System.Text;

namespace CheckIfWordIsValidAfterSubstitutions
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = "abccba";
            Console.WriteLine(IsValid(S));
        }
        static bool IsValid(string S)
        {
            StringBuilder record = new StringBuilder();
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == 'a' || S[i] == 'b')
                    record.Append(S[i]);
                else if(S[i] == 'c')
                {
                    if (record.Length >= 2 && record[record.Length - 1] == 'b' && record[record.Length - 2] == 'a')
                        record.Remove(record.Length - 2, 2);
                    else
                        record.Append(S[i]);
                }
            }
            return record.Length == 0;
        }
    }
}
