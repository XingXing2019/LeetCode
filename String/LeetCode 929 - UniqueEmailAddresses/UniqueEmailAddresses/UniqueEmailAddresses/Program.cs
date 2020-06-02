//第一种方法时使用状态机原理，设置befPlus，aftPlus和aftAt代表'+'前'+'后和'@'后三种状态，根据不同状态设置逻辑添加字符。这种方法较慢，因为要遍历整个字符串。
//第二种方法是先将email以'@'分割，只遍历'@'前的字符串，遇到'.'就continue，遇到'+'就break，其他字符加入结果。
//最后将'@'和其后的字符串认为加入。
//两种方法都是在将不重复的email加入字典，最后返回字典中键值对的个数。
using System;
using System.Collections.Generic;

namespace UniqueEmailAddresses
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] emails = { "test.email+alex@leetcode.com", "test.e.mail+bob.cathy@leetcode.com", "testemail+david@lee.tcode.com" };
            Console.WriteLine(NumUniqueEmails2(emails));
        }

        static int NumUniqueEmails1(string[] emails)
        {
            const string befPlus = "befPlus";
            const string aftPlus = "aftPlus";
            const string aftAt = "aftAt";
            Dictionary<string, int> results = new Dictionary<string, int>();
            foreach (var email in emails)
            {
                string state = befPlus;
                string res = "";
                for (int i = 0; i < email.Length; i++)
                {
                    switch (state)
                    {
                        case befPlus:
                            if (email[i] != '.' && email[i] != '+' && email[i] != '@')
                                res += email[i];
                            else if (email[i] == '+')
                                state = aftPlus;
                            else if (email[i] == '@')
                            {
                                res += email[i];
                                state = aftAt;
                            }
                            break;
                        case aftPlus:
                            if (email[i] == '@')
                            {
                                res += email[i];
                                state = aftAt;
                            }
                            break;
                        case aftAt:
                            res += email[i];
                            break;
                    }
                }
                if (!results.ContainsKey(res))
                    results.Add(res, 1);
            }
            return results.Count;
        }
        static int NumUniqueEmails2(string[] emails)
        {
            Dictionary<string, int> results = new Dictionary<string, int>();
            foreach (var email in emails)
            {
                var emailParts = email.Split('@');
                string localName = emailParts[0];
                string domainName = emailParts[1];
                string shortEmail = "";
                for (int i = 0; i < localName.Length; i++)
                {
                    if (localName[i] == '.')
                        continue;
                    if (localName[i] == '+')
                        break;
                    shortEmail += localName[i];
                }
                shortEmail += '@';
                shortEmail += domainName;
                if (!results.ContainsKey(shortEmail))
                    results.Add(shortEmail, 1);
            }
            return results.Count;
        }
    }
}
