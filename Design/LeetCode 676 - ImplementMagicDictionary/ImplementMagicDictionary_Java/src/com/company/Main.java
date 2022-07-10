package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
}

class MagicDictionary {
    Map<Integer, List<String>> map;
    public MagicDictionary() {
        map = new HashMap<>();
    }

    public void buildDict(String[] dictionary) {
        for (String word : dictionary) {
            if (!map.containsKey(word.length()))
                map.put(word.length(), new ArrayList<>());
            map.get(word.length()).add(word);
        }
    }

    public boolean search(String searchWord) {
        List<String> words = map.getOrDefault(searchWord.length(), new ArrayList<>());
        for (String word : words) {
            if (canChange(searchWord, word))
                return true;
        }
        return false;
    }

    private boolean canChange(String word, String target) {
        if (word.length() != target.length() || word.equals(target))
            return false;
        for (int i = 0; i < word.length(); i++) {
            String prefix = word.substring(0, i);
            String suffix = word.substring(i + 1, word.length());
            if (target.startsWith(prefix) && target.endsWith(suffix))
                return true;
        }
        return false;
    }
}