using System;
using System.Linq;
using System.Text;

namespace DesignBitset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class Bitset
    {
        private int[] bits;
        private int count;
        private bool isFlip;
        public Bitset(int size)
        {
            bits = new int[size];
        }

        public void Fix(int idx)
        {
            if (!isFlip && bits[idx] == 0 || isFlip && bits[idx] == 1)
                count++;
            bits[idx] = isFlip ? 0 : 1;
        }

        public void Unfix(int idx)
        {
            if (!isFlip && bits[idx] == 1 || isFlip && bits[idx] == 0)
                count--;
            bits[idx] = isFlip ? 1 : 0;
        }

        public void Flip()
        {
            isFlip = !isFlip;
            count = bits.Length - count;
        }

        public bool All() => count == bits.Length;

        public bool One() => count != 0;

        public int Count() => count;

        public string ToString() => string.Join("", bits.Select(x => isFlip ? x ^ 1 : x));
    }
}
