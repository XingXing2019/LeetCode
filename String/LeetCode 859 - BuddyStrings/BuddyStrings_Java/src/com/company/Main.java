package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public boolean buddyStrings(String s, String goal) {
        if (s.length() != goal.length()) return false;
        int[] freqS = new int[26];
        int[] freqGoal = new int[26];
        for (int i = 0; i < s.length(); i++) {
            freqS[s.charAt(i) - 'a']++;
            freqGoal[goal.charAt(i) - 'a']++;
        }
        for (int i = 0; i < 26; i++) {
            if (freqS[i] == freqGoal[i]) continue;
            return false;
        }
        if (s.equals(goal))
            return Arrays.stream(freqS).anyMatch(x -> x > 1);
        int diff = 0;
        for (int i = 0; i < s.length(); i++) {
            if (s.charAt(i) != goal.charAt(i))
                diff++;
        }
        return diff <= 2;
    }
}
