using System.Collections.Generic;

namespace LRUCache
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    public class LRUCache
    {
        private readonly int _capacity;
        private Dictionary<int, int> _cache;
        private List<int> _index;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _cache = new Dictionary<int, int>();
            _index = new List<int>();
        }

        public int Get(int key)
        {
            if (!_cache.ContainsKey(key))
                return -1;
            OrderIndex(key);
            return _cache[key];
        }

        public void Put(int key, int value)
        {
            if (!_cache.ContainsKey(key) && _cache.Count >= _capacity)
            {
                _cache.Remove(_index[0]);
                _index.RemoveAt(0);
            }
            _cache[key] = value;
            OrderIndex(key);
        }

        private void OrderIndex(int key)
        {
            _index.Remove(key);
            _index.Add(key);
        }
    }
}
