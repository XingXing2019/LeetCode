using System;
using System.Linq;

namespace MaximumNumberOfWordsFoundInSentences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MostWordsFound(string[] sentences)
        {
            return sentences.Max(x => x.Split(' ').Length);
        }
    }
}
