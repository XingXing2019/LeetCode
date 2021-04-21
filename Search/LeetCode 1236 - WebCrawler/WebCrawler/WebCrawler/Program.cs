using System;
using System.Collections.Generic;
using System.Linq;

namespace WebCrawler
{
	class HtmlParser
	{
		public List<String> GetUrls(String url)
		{
			return null;
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			
		}
		public static IList<string> Crawl(string startUrl, HtmlParser htmlParser)
		{
			var hostName = startUrl.Split('/')[2];
			var queue = new Queue<string>();
			queue.Enqueue(startUrl);
			var res = new HashSet<string> {startUrl};
			while (queue.Count != 0)
			{
				var cur = queue.Dequeue();
				foreach (var next in htmlParser.GetUrls(cur))
				{
					var nextHost = next.Split('/')[2];
					if(nextHost == hostName && res.Add(next))
						queue.Enqueue(next);
				}
			}
			return res.ToList();
		}
	}
}
