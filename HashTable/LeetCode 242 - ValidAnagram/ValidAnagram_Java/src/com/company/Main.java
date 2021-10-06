package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public boolean isAnagram(String s, String t) {
        if (s.length() != t.length()) return false;
        int[] letters = new int[26];
        for (Character l : s.toCharArray())
            letters[l - 'a']++;
        for (Character l : t.toCharArray()) {
            letters[l - 'a']--;
            if (letters[l - 'a'] < 0)
                return false;
        }
        return true;
    }
}
