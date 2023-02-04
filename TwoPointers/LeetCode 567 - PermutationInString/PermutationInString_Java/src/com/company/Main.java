package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public boolean checkInclusion(String s1, String s2) {
        if (s1.length() > s2.length()) return false;
        int[] letters = new int[26];
        for (int i = 0; i < s1.length(); i++) {
            letters[s1.charAt(i) - 'a']++;
            letters[s2.charAt(i) - 'a']--;
        }
        for (int i = s1.length(); i < s2.length(); i++) {
            if (Arrays.stream(letters).allMatch(x -> x == 0))
                return true;
            letters[s2.charAt(i) - 'a']--;
            letters[s2.charAt(i - s1.length()) - 'a']++;
        }
        return Arrays.stream(letters).allMatch(x -> x == 0);
    }
}
