package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    class TrieNode {
        boolean isWord;
        TrieNode[] children;
        public TrieNode() {
            children = new TrieNode[26];
        }
    }
    public String longestWord(String[] words) {
        TrieNode root = new TrieNode();
        for (String word : words) {
            TrieNode point = root;
            for (Character l : word.toCharArray()) {
                if (point.children[l - 'a'] == null)
                    point.children[l - 'a'] = new TrieNode();
                point = point.children[l - 'a'];
            }
            point.isWord = true;
        }
        String res = "";
        for (String word : words) {
            TrieNode point = root;
            boolean isCandidate = true;
            for (Character l : word.toCharArray()) {
                if (point.children[l - 'a'] == null || !point.children[l - 'a'].isWord){
                    isCandidate = false;
                    break;
                }
                point = point.children[l - 'a'];
            }
            if (isCandidate && word.length() > res.length())
                res = word;
            else if (isCandidate && word.length() == res.length() && word.compareTo(res) < 0)
                res = word;
        }
        return res;
    }
}
