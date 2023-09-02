package com.company;

import java.util.HashSet;

public class Main {

    public static void main(String[] args) {
	    String s = "zdhxo";
        String[] dictionary = {"zdhx","xo"};
        System.out.println(minExtraChar(s, dictionary));
    }

    public static int minExtraChar(String s, String[] dictionary) {
        int[] dp = new int[s.length()];
        HashSet<String> words = new HashSet<>();
        for (String word : dictionary)
            words.add(word);
        for (int i = 0; i < dp.length; i++) {
            int min = Integer.MAX_VALUE;
            for (int j = 0; j <= i; j++) {
                String word = s.substring(i - j, i + 1);
                if (!words.contains(word))
                    min = Math.min(min, i == 0 ? 1 : dp[i - 1] + 1);
                else
                    min = Math.min(min, i - word.length() >= 0 ? dp[i - word.length()] : 0);
            }
            dp[i] = min;
        }
        return dp[dp.length - 1];
    }
}
