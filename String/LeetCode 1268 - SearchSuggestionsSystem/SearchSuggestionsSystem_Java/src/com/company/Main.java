package com.company;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        String[] products = {"mobile", "mouse", "moneypot", "monitor", "mousepad"};
        String searchWord = "mouse";
        System.out.println(suggestedProducts(products, searchWord));
    }

    static class TrieNode {
        public List<String> words;
        public TrieNode[] children;

        public TrieNode() {
            words = new ArrayList<>();
            children = new TrieNode[26];
        }
    }

    public static List<List<String>> suggestedProducts(String[] products, String searchWord) {
        TrieNode root = new TrieNode();
        for (String product : products) {
            TrieNode cur = root;
            for (int i = 0; i < product.length(); i++) {
                if (cur.children[product.charAt(i) - 'a'] == null)
                    cur.children[product.charAt(i) - 'a'] = new TrieNode();
                cur = cur.children[product.charAt(i) - 'a'];
                cur.words.add(product);
                Collections.sort(cur.words);
                if (cur.words.size() > 3)
                    cur.words.remove(cur.words.size() - 1);
            }
        }
        List<List<String>> res = new ArrayList<>();
        TrieNode point = root;
        for (int i = 0; i < searchWord.length(); i++) {
            if (point.children[searchWord.charAt(i) - 'a'] == null) {
                for (int j = 0; j < searchWord.length() - i; j++)
                    res.add(new ArrayList<>());
                return res;
            }
            res.add(point.children[searchWord.charAt(i) - 'a'].words);
            point = point.children[searchWord.charAt(i) - 'a'];
        }
        return res;
    }
}
