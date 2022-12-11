using System;

namespace DesignMemoryAllocator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var allocator = new Allocator(10);
            allocator.Allocate(1, 1);
            allocator.Allocate(1, 2);
            allocator.Allocate(1, 3);
            allocator.Free(2);
            allocator.Allocate(3, 4);
            allocator.Allocate(1, 1);
            allocator.Allocate(1, 1);
            allocator.Free(1);
            allocator.Allocate(10, 2);
            allocator.Free(7);
        }
    }

    public class Allocator
    {
        private int[] memory;
        public Allocator(int n)
        {
            memory = new int[n];
        }

        public int Allocate(int size, int mID)
        {
            int index = 0;
            while (index < memory.Length)
            {
                var temp = size;
                while (index < memory.Length && memory[index] == 0 && temp != 0)
                {
                    index++;
                    temp--;
                }
                if (temp != 0)
                {
                    index++;
                    continue;
                }
                while (temp != size)
                {
                    memory[--index] = mID;
                    temp++;
                }
                return index;
            }
            return -1;
        }

        public int Free(int mID)
        {
            var count = 0;
            for (int i = 0; i < memory.Length; i++)
            {
                if (memory[i] != mID) continue;
                memory[i] = 0;
                count++;
            }
            return count;
        }
    }
}
