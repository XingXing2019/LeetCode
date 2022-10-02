using System;

namespace LongestUploadedPrefix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class LUPrefix
    {
        private int index = 1;
        private bool[] videos;
        public LUPrefix(int n)
        {
            videos = new bool[n + 1];
        }

        public void Upload(int video)
        {
            videos[video] = true;
        }

        public int Longest()
        {
            while (index < videos.Length && videos[index])
                index++;
            return index - 1;
        }
    }

}
