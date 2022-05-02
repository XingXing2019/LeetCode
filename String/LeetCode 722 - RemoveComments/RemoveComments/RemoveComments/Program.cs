using System;
using System.Collections.Generic;
using System.Text;

namespace RemoveComments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] code =
            {
                "a/*/b//*c","blank","d/*/e*//f"
            };
            Console.WriteLine(RemoveComments(code));
        }

        public static IList<string> RemoveComments(string[] source)
        {
            var res = new List<string>();
            var sb = new StringBuilder();
            int IsComment = 0; //0: normal; 1://; 2: /*
            for (int i = 0; i < source.Length; i++)
            {
                for (int j = 0; j < source[i].Length; j++)
                {
                    if (IsComment == 0)
                    {
                        if (j < source[i].Length - 1 && source[i][j] == '/')
                        {
                            if (source[i][j + 1] == '/')
                            {
                                IsComment = 1;
                                break;
                            }
                            if (source[i][j + 1] == '*')
                            {
                                IsComment = 2;
                                j++;
                            }
                            else
                                sb.Append(source[i][j]);
                        }
                        else
                            sb.Append(source[i][j]);
                    }
                    else if (IsComment == 1)
                        continue;
                    else if (j < source[i].Length - 1 && source[i][j] == '*' && source[i][j + 1] == '/')
                    {
                        IsComment = 0;
                        j++;
                    }
                }
                if (IsComment == 2) continue;
                if (sb.Length != 0)
                    res.Add(sb.ToString());
                sb = new StringBuilder();
                IsComment = 0;
            }
            return res;
        }
    }
}
