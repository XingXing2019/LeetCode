package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
}

class TrieNode {
    int val;
    TrieNode[] children;
    boolean isWord;
    public TrieNode(){
        children = new TrieNode[26];
    }
}

class Trie {

    TrieNode root;
    public Trie() {
        root = new TrieNode();
    }
    public void insert(String word) {
        TrieNode point = root;
        for (int i = 0; i < word.length(); i++) {
            if(point.children[word.charAt(i) - 'a'] == null)
                point.children[word.charAt(i) - 'a'] = new TrieNode();
            point = point.children[word.charAt(i) - 'a'];
        }
        point.isWord = true;
    }
    public boolean search(String word) {
        TrieNode point = root;
        for (int i = 0; i < word.length(); i++) {
            if(point.children[word.charAt(i) - 'a'] == null)
                return false;
            point = point.children[word.charAt(i) - 'a'];
        }
        return point.isWord;
    }
    public boolean startsWith(String prefix) {
        TrieNode point = root;
        for (int i = 0; i < prefix.length(); i++) {
            if(point.children[prefix.charAt(i) - 'a'] == null)
                return false;
            point = point.children[prefix.charAt(i) - 'a'];
        }
        return true;
    }
}
