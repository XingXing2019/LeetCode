package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int calculateTime(String keyboard, String word) {
        int[] indexs = new int[26];
        for (int i = 0; i < keyboard.length(); i++)
            indexs[keyboard.charAt(i) - 'a'] = i;
        int res = 0, pos = 0;
        for (int i = 0; i < word.length(); i++) {
            res += Math.abs(indexs[word.charAt(i) - 'a'] - pos);
            pos = indexs[word.charAt(i) - 'a'];
        }
        return res;
    }
}
