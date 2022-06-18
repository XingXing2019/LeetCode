package com.company;

import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
        WordFilter filter = new WordFilter(new String[] {"apple"});
        System.out.println(filter.f("a", "e"));
    }
}

class WordFilter {
    class TrieNode {
        TrieNode[] children;
        HashSet<Integer> indexes;
        public TrieNode() {
            children = new TrieNode[26];
            indexes = new HashSet<>();
        }
    }

    private TrieNode prefixRoot;
    private TrieNode suffixRoot;
    private Map<String, Integer> cache;
    public WordFilter(String[] words) {
        prefixRoot = new TrieNode();
        suffixRoot = new TrieNode();
        cache = new HashMap<>();
        for (int i = 0; i < words.length; i++) {
            String word = words[i];
            TrieNode p1 = prefixRoot;
            TrieNode p2 = suffixRoot;
            addWord(word, i, p1);
            addWord(reverseWord(word), i, p2);
        }
    }

    public int f(String prefix, String suffix) {
        if (cache.containsKey(prefix + ':' + suffix))
            return cache.get(prefix + ':' + suffix);
        TrieNode p1 = prefixRoot;
        TrieNode p2 = suffixRoot;
        HashSet<Integer> prefixIndexes = findIndexes(prefix, p1);
        HashSet<Integer> suffixIndexes = findIndexes(reverseWord(suffix), p2);
        if (prefixIndexes == null || suffixIndexes == null)
            return -1;
        int res = -1;
        for (int index : prefixIndexes) {
            if (!suffixIndexes.contains(index))
                continue;
            res = Math.max(res, index);
        }
        cache.put(prefix + ':' + suffix, res);
        return res;
    }


    private void addWord(String word, int index, TrieNode point) {
        for (int i = 0; i < word.length(); i++) {
            if (point.children[word.charAt(i) - 'a'] == null)
                point.children[word.charAt(i) - 'a'] = new TrieNode();
            point = point.children[word.charAt(i) - 'a'];
            point.indexes.add(index);
        }
    }

    private String reverseWord(String word) {
        StringBuilder res = new StringBuilder();
        for (int i = word.length() - 1; i >= 0; i--)
            res.append(word.charAt(i));
        return res.toString();
    }

    private HashSet<Integer> findIndexes(String word, TrieNode point) {
        for (int i = 0; i < word.length(); i++) {
            if (point.children[word.charAt(i) - 'a'] == null)
                return null;
            point = point.children[word.charAt(i) - 'a'];
        }
        return point.indexes;
    }
}