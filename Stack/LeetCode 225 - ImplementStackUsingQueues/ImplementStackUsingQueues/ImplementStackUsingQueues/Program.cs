using System;
using System.Collections;

namespace ImplementStackUsingQueues
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class MyStack
    {
        private Queue data = new Queue();
        public MyStack()
        {

        }
        public void Push(int x)
        {
            Queue tem = new Queue();
            tem.Enqueue(x);
            while (data.Count != 0)
            {
                tem.Enqueue((int)data.Dequeue());
            }
            while (tem.Count != 0)
            {
                data.Enqueue((int)tem.Dequeue());
            }
        }
        public int Pop()
        {
            return (int)data.Dequeue();
        }
        public int Top()
        {
            return (int)data.Peek();
        }
        public bool Empty()
        {
            return data.Count == 0 ? true : false;
        }
    }
}
