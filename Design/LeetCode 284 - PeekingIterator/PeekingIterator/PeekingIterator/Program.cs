using System;
using System.Collections.Generic;

namespace PeekingIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    class PeekingIterator
    {
        private IEnumerator<int> _iterator;
        private bool _hasNext;
        public PeekingIterator(IEnumerator<int> iterator)
        {
            _iterator = iterator;
            _hasNext = true;
        }

        public int Peek()
        {
            return _iterator.Current;
        }

        public int Next()
        {
            var res = _iterator.Current;
            _hasNext = _iterator.MoveNext();
            return res;
        }

        public bool HasNext()
        {
            return _hasNext;
        }
    }
}
