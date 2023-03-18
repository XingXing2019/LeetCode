using System;
using System.Collections.Generic;

namespace DesignBrowserHistory
{
    class Program
    {
        static void Main(string[] args)
        {
            string homepage = "leetcode";
            var browser = new BrowserHistory(homepage);
            browser.Visit("google");
            browser.Visit("facebook");
            browser.Visit("youtube");

            Console.WriteLine(browser.Back(1));
            Console.WriteLine(browser.Back(1));

            Console.WriteLine(browser.Forward(1));

            browser.Visit("linkedin");

            Console.WriteLine(browser.Forward(2));
            Console.WriteLine(browser.Back(2));
            Console.WriteLine(browser.Back(7));
        }
    }
    public class BrowserHistory
    {
        private Stack<string> history;
        private Stack<string> future;
        public BrowserHistory(string homepage)
        {
            history = new Stack<string>();
            history.Push(homepage);
            future = new Stack<string>();
        }

        public void Visit(string url)
        {
            history.Push(url);
            future = new Stack<string>();
        }

        public string Back(int steps)
        {
            while (steps != 0 && history.Count > 1)
            {
                future.Push(history.Pop());
                steps--;
            }
            return history.Peek();
        }

        public string Forward(int steps)
        {
            while (steps != 0 && future.Count > 0)
            {
                history.Push(future.Pop());
                steps--;
            }
            return history.Peek();
        }
    }
}
