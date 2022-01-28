package com.company;

public class Main {

    public static void main(String[] args) {
        WordDictionary obj = new WordDictionary();
        obj.addWord("at");
        System.out.println(obj.search("a"));
    }
}

class WordDictionary {
    class TrieNode {
        public TrieNode[] children;
        public boolean isWord;

        public TrieNode() {
            children = new TrieNode[26];
        }
    }

    private TrieNode root;

    public WordDictionary() {
        root = new TrieNode();
    }

    public void addWord(String word) {
        TrieNode pointer = root;
        for (int i = 0; i < word.length(); i++) {
            Character letter = word.charAt(i);
            if (pointer.children[letter - 'a'] == null)
                pointer.children[letter - 'a'] = new TrieNode();
            pointer = pointer.children[letter - 'a'];
        }
        pointer.isWord = true;
    }

    public boolean search(String word) {
        TrieNode pointer = root;
        return dfs(pointer, word, 0);
    }

    private Boolean dfs(TrieNode pointer, String word, int index) {
        if (pointer == null || index > word.length()) return false;
        if (index == word.length()) return pointer.isWord;
        Character letter = word.charAt(index);
        if (letter == '.') {
            for (int i = 0; i < pointer.children.length; i++) {
                if (dfs(pointer.children[i], word, index + 1))
                    return true;
            }
            return false;
        } else {
            if (pointer.children[letter - 'a'] == null)
                return false;
            return dfs(pointer.children[letter - 'a'], word, index + 1);
        }
    }
}
