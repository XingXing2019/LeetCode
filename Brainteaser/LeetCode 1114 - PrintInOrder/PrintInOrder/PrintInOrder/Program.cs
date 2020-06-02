using System;
using System.Threading;

namespace PrintInOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class Foo
    {
        private AutoResetEvent _second;
        private AutoResetEvent _third;
        public Foo()
        {
            _second = new AutoResetEvent(false);
            _third = new AutoResetEvent(false);
        }

        public void First(Action printFirst)
        {

            printFirst();
            _second.Set();
        }

        public void Second(Action printSecond)
        {
            _second.WaitOne();
            printSecond();
            _third.Set();
        }

        public void Third(Action printThird)
        {
            _third.WaitOne();
            printThird();
        }
    }
}
