//创建ransomMap和magazineMap数组记录ransomNote和magazine中字符出现的次数。长度设为128(因为一共有128个字符)。
//遍历ransomNote和magazine，将字符的个数存入相应的数组(使相应位置加一)。
//遍历两个数组，如果某一位置上ransomMap的字符数量多于magazine在该位置的字符数量，证明magazine中字符不够用，则立即返回false。
//遍历结束后如仍未返回，在返回true。
using System;

namespace RansomNote
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public bool CanConstruct(string ransomNote, string magazine)
        {
            int[] ransomMap = new int[128];
            int[] magazineMap = new int[128];
            for (int i = 0; i < ransomNote.Length; i++)
                ransomMap[ransomNote[i]]++;
            for (int i = 0; i < magazine.Length; i++)
                magazineMap[magazine[i]]++;
            for (int i = 0; i < ransomMap.Length; i++)
                if (ransomMap[i] > magazineMap[i])
                    return false;
            return true;
        }
    }
}
