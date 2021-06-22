package com.company;

import java.util.ArrayDeque;
import java.util.ArrayList;
import java.util.List;
import java.util.Queue;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int numMatchingSubseq(String s, String[] words) {
        Queue<StringBuilder>[] record = new ArrayDeque[26];
        for (int i = 0; i < 26; i++)
            record[i] = new ArrayDeque<>();
        int res = 0;
        for (String word : words)
            record[word.charAt(0) - 'a'].offer(new StringBuilder(word));
        for (Character l : s.toCharArray()) {
            Queue<StringBuilder> candidates = record[l - 'a'];
            int size = candidates.size();
            for (int i = 0; i < size; i++) {
                StringBuilder word = candidates.poll();
                word.deleteCharAt(0);
                if (word.length() == 0)
                    res++;
                else
                    record[word.charAt(0) - 'a'].offer(word);
            }
        }
        return res;
    }
}
