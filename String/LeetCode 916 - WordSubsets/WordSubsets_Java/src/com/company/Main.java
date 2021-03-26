package com.company;

import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public List<String> wordSubsets(String[] A, String[] B) {
        int[] letters = new int[26];
        List<String> res = new ArrayList<>();
        for (String b : B) {
            int[] temp = new int[26];
            for (int i = 0; i < b.length(); i++)
                temp[b.charAt(i) - 'a']++;
            for (int i = 0; i < 26; i++)
                letters[i] = Math.max(letters[i], temp[i]);
        }
        for (String a : A){
            int[] temp = new int[26];
            for (int i = 0; i < a.length(); i++)
                temp[a.charAt(i) - 'a']++;
            boolean isRes = true;
            for (int i = 0; i < 26; i++) {
                if(temp[i] < letters[i]){
                    isRes = false;
                    break;
                }
            }
            if(isRes) res.add(a);
        }
        return res;
    }
}
