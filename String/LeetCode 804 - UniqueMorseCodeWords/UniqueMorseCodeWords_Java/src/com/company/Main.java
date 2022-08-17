package com.company;

import java.util.HashSet;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int uniqueMorseRepresentations(String[] words) {
        String[] morse = {".-", "-...", "-.-.", "-..", ".",
                "..-.", "--.", "....", "..", ".---",
                "-.-", ".-..", "--", "-.", "---",
                ".--.", "--.-", ".-.", "...", "-",
                "..-", "...-", ".--", "-..-", "-.--",
                "--.."};
        HashSet<String> set = new HashSet<String>();
        for (String word : words) {
            set.add(encode(word, morse));
        }
        return set.size();
    }

    public String encode(String word, String[] morse) {
        StringBuilder res = new StringBuilder();
        for (char l : word.toCharArray()) {
            res.append(morse[l - 'a']);
        }
        return res.toString();
    }
}
