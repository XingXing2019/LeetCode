package com.company;

import java.util.HashMap;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
        String[] words = {"hello", "hello"};
        String order = "abcdefghijklmnopqrstuvwxyz";
        System.out.println(isAlienSorted(words, order));
    }

    public static boolean isAlienSorted(String[] words, String order) {
        Map<Character, Integer> map = new HashMap<>();
        for (int i = 0; i < order.length(); i++)
            map.put(order.charAt(i), i + 1);
        for (int i = 1; i < words.length; i++) {
            boolean flag = false;
            String word1 = words[i - 1], word2 = words[i];
            for (int j = 0; j < word1.length() && j < word2.length(); j++) {
                if (map.get(word1.charAt(j)) == map.get(word2.charAt(j)))
                    continue;
                if (map.get(word1.charAt(j)) < map.get(word2.charAt(j))) {
                    flag = true;
                    break;
                } else
                    return false;
            }
            if (!flag && word1.length() > word2.length())
                return false;
        }
        return true;
    }
}
