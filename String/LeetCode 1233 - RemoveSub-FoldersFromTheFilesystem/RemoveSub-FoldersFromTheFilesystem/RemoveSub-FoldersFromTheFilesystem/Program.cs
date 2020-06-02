//创建CheckSU币folder方法，检查一个folder是否为另一个的子folder。
//在主方法中对folder排序，同样开头的字符串会被排在一起。创建li和hi指针，初始值指向第一个元素。
//在hi不越界的条件下遍历，如果li指针指向的元素为hi指针指向元素的子文件夹，则hi指针前进一位。否则将li指针指向元素加入res，然后使li指向hi，并使hi前进一位。
//遍历结束后将li指针最后一次指向的元素加入res，并返回。
using System;
using System.Collections.Generic;

namespace RemoveSub_FoldersFromTheFilesystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] folder = { "/a", "/a/b", "/c/d", "/c/d/e", "/c/f" };
            Console.WriteLine(RemoveSubfolders(folder));
        }
        static IList<string> RemoveSubfolders(string[] folder)
        {
            List<string> res = new List<string>();
            Array.Sort(folder);
            int li = 0;
            int hi = 0;
            while (hi < folder.Length)
            {
                if (CheckSubfolder(folder[hi], folder[li]))
                    hi++;
                else
                {
                    res.Add(folder[li]);
                    li = hi++;
                }
            }
            res.Add(folder[li]);
            return res;
        }

        static bool CheckSubfolder(string path1, string path2) {
            string[] folder1 = path1.Split('/');
            string[] folder2 = path2.Split('/');
            int p1 = 0;
            int p2 = 0;
            while (p1 < folder1.Length && p2 < folder2.Length)
            {
                if (folder1[p1] != folder2[p2])
                    return false;
                p1++;
                p2++;
            }
            return folder2.Length <= folder1.Length;
        }
    }
}
