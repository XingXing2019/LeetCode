using System;
using System.Collections.Generic;
using System.Linq;

namespace TweetCountsPerFrequency
{
    class Program
    {
        static void Main(string[] args)
        {
            var counts = new TweetCounts();
            counts.RecordTweet("tweet0", 13);
            counts.RecordTweet("tweet1", 16);
            counts.RecordTweet("tweet2", 12);
            counts.RecordTweet("tweet3", 18);
            counts.RecordTweet("tweet4", 82);
            counts.RecordTweet("tweet3", 89);

            counts.GetTweetCountsPerFrequency("day", "tweet0", 89, 9471);
            counts.GetTweetCountsPerFrequency("hour", "tweet3", 13, 4024);
        }
    }
    public class TweetCounts
    {
        private Dictionary<string, List<int>> record;
        private Dictionary<string, int> intervals;
        public TweetCounts()
        {
            record = new Dictionary<string, List<int>>();
            intervals = new Dictionary<string, int>
            {
                {"minute", 60},
                {"hour", 3600},
                {"day", 86_400}
            };
        }

        public void RecordTweet(string tweetName, int time)
        {
            if (!record.ContainsKey(tweetName))
                record[tweetName] = new List<int> {time};
            else
                record[tweetName].Add(time);
        }

        public IList<int> GetTweetCountsPerFrequency(string freq, string tweetName, int startTime, int endTime)
        {
            var times = record[tweetName].Where(x => x >= startTime && x <= endTime).ToArray();
            var interval = intervals[freq];
            var length = (endTime - startTime + interval) / interval;
            var res = new int[length];
            foreach (var time in times)
            {
                int index = (time - startTime) / interval;
                res[index]++;
            }
            return res;
        }
    }
}
