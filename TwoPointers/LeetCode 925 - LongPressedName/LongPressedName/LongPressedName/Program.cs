//如果name和typed的首字母不相同，则返回false。否则创建nPointer和tPointer指针，分别指向name和typed的第二个字母。
//在nPointer和tPointer不越界的条件下遍历。如果两个指针所指向字母相同，则使两个指针都向前移动一位。
//否则如果tPointer指向字母与其前一字母不相同，则返回false。否则在tPointer不越界的条件下找到下一个不同的字母。
//遍历结束后，如果nPointer仍未越界，证明name中还有元素未被typed包含，则返回false。否则返回true。
using System;

namespace LongPressedName
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "alex";
            string typed = "alexxr";
            Console.WriteLine(IsLongPressedName(name, typed));
        }
        static bool IsLongPressedName(string name, string typed)
        {
            if (name[0] != typed[0]) return false;
            int nPointer = 1, tPointer = 1;
            while (nPointer < name.Length && tPointer < typed.Length)
            {
                if (name[nPointer] == typed[tPointer])
                {
                    nPointer++;
                    tPointer++;
                }
                else
                {
                    if (typed[tPointer] != typed[tPointer - 1])
                        return false;
                    while (tPointer < typed.Length && typed[tPointer] == typed[tPointer - 1])
                        tPointer++;
                }
            }
            if (nPointer < name.Length)
                return false;
            tPointer++;
            while (tPointer < typed.Length)
            {
                if (typed[tPointer] != typed[tPointer - 1])
                    return false;
            }
            return true;
        }
    }
}
