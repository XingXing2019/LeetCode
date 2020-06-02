using System;
using System.Collections.Generic;

namespace DesignTwitter
{
    class Program
    {
        static void Main(string[] args)
        {
            var twitter = new Twitter();
            twitter.PostTweet(1, 5);
            twitter.PostTweet(1, 3);
            twitter.PostTweet(1, 101);
            twitter.PostTweet(1, 13);
            twitter.PostTweet(1, 10);
            twitter.PostTweet(1, 2);
            twitter.PostTweet(1, 94);
            twitter.PostTweet(1, 505);
            twitter.PostTweet(1, 333);
            twitter.PostTweet(1, 22);
            twitter.PostTweet(1, 11);
            twitter.GetNewsFeed(1);

        }
    }
    public class Twitter
    {
        private Dictionary<int, HashSet<int>> follow;
        private List<int[]> messages;
        public Twitter()
        {
            follow = new Dictionary<int, HashSet<int>>();
            messages = new List<int[]>();
        }

        public void PostTweet(int userId, int tweetId)
        {
            if(!follow.ContainsKey(userId))
                follow[userId] = new HashSet<int>{userId};
            else
                follow[userId].Add(userId);
            messages.Add(new int[] { userId, tweetId });
        }

        public IList<int> GetNewsFeed(int userId)
        {
            var res = new List<int>();
            var followees = new List<int>{userId};
            if(follow.ContainsKey(userId))
                followees.AddRange(follow[userId]);
            for (int i = messages.Count - 1; i >= 0 && res.Count < 10; i--)
            {
                if(messages[i][0] == userId || followees.Contains(messages[i][0]))
                    res.Add(messages[i][1]);
            }
            return res;
        }

        public void Follow(int followerId, int followeeId)
        {
            if (!follow.ContainsKey(followerId))
                follow[followerId] = new HashSet<int>{ followeeId };
            else
                follow[followerId].Add(followeeId);
        }

        public void Unfollow(int followerId, int followeeId)
        {
            if (follow.ContainsKey(followerId))
                follow[followerId].Remove(followeeId);
        }
    }
}
