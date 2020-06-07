using System;
using System.Collections.Generic;

namespace SnapshotArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new SnapshotArray(2);

            Console.WriteLine(arr.Snap());
            Console.WriteLine(arr.Get(1, 0));
            Console.WriteLine(arr.Get(0, 0));

            arr.Set(1, 8);
            Console.WriteLine(arr.Get(1, 0));
            arr.Set(0, 20);
            Console.WriteLine(arr.Get(0, 0));
            arr.Set(0, 7);
        }

    }
    public class SnapshotArray
    {
        private Dictionary<int, int> changes;
        private List<Dictionary<int, int>> snaps;
        public SnapshotArray(int length)
        {
            changes = new Dictionary<int, int>();
            snaps = new List<Dictionary<int, int>>();
        }

        public void Set(int index, int val)
        {
            changes[index] = val;
        }

        public int Snap()
        {
            snaps.Add(new Dictionary<int, int>(changes));
            return snaps.Count - 1;
        }

        public int Get(int index, int snap_id)
        {
            return snaps[snap_id].ContainsKey(index) ? snaps[snap_id][index] : 0;
        }
    }
}
