package com.company;

import java.util.HashSet;
import java.util.List;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    int res;
    public int maxLength(List<String> arr) {
        dfs(arr, 0, 0, new int[26]);
        return res;
    }

    public void dfs(List<String> arr, int start, int len, int[] letter){
        res = Math.max(res, len);
        for (int i = start; i < arr.size(); i++) {
            String word = arr.get(i);
            boolean noDuplicate = true;
            HashSet<Character> seen = new HashSet<>();
            for (int j = 0; j < word.length(); j++) {
                if(letter[word.charAt(j) - 'a'] > 0 || !seen.add(word.charAt(j))){
                    noDuplicate = false;
                    break;
                }
            }
            if(!noDuplicate) continue;
            for (int j = 0; j < word.length(); j++)
                letter[word.charAt(j) - 'a']++;
            dfs(arr, i + 1, len + word.length(), letter);
            for (int j = 0; j < word.length(); j++)
                letter[word.charAt(j) - 'a']--;
        }
    }
}
