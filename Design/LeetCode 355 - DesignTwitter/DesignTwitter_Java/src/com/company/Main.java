package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
        var twitter = new Twitter();
        twitter.postTweet(1, 5);
        twitter.getNewsFeed(1);
        twitter.follow(1, 2);
        twitter.postTweet(2, 6);
        twitter.getNewsFeed(1);
        twitter.unfollow(1, 2);
        twitter.getNewsFeed(5);
    }
}
class Twitter {
    private Map<Integer, HashSet<Integer>> _person;
    private Map<Integer, List<int[]>> _messages;
    private int _time;
    public Twitter() {
        _person = new HashMap<>();
        _messages = new HashMap<>();
        _time = 0;
    }
    public void postTweet(int userId, int tweetId) {
        if(!_messages.containsKey(userId))
            _messages.put(userId, new ArrayList<>());
        if (!_person.containsKey(userId))
            _person.put(userId, new HashSet<>());
        _messages.get(userId).add(new int[]{_time, tweetId});
        _time++;
    }
    public List<Integer> getNewsFeed(int userId) {
        PriorityQueue<int[]> heap = new PriorityQueue<>((a, b) -> (b[0] - a[0]));
        HashSet<Integer> followees = _person.getOrDefault(userId, new HashSet<>());
        for (Integer followee : followees){
            List<int[]> messages = _messages.getOrDefault(followee, new ArrayList<>());
            for (int[] msg : messages)
                heap.offer(msg);
        }
        for (var msg : _messages.getOrDefault(userId, new ArrayList<>()))
            heap.offer(msg);
        List<Integer> res = new ArrayList<>();
        while (!heap.isEmpty() && res.size() < 10)
            res.add(heap.poll()[1]);
        return res;
    }
    public void follow(int followerId, int followeeId) {
        if (!_person.containsKey(followerId))
            _person.put(followerId, new HashSet<>());
        _person.get(followerId).add(followeeId);
    }
    public void unfollow(int followerId, int followeeId) {
        _person.get(followerId).remove(followeeId);
    }
}
