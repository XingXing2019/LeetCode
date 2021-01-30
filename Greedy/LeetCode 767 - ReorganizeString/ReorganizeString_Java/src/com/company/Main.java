package com.company;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public String reorganizeString(String S) {
        int[] letters = new int[26];
        for (int i = 0; i < S.length(); i++)
            letters[S.charAt(i) - 'a']++;
        List<int[]> countLetters = new ArrayList<>();
        for (int i = 0; i < letters.length; i++) {
            if(letters[i] == 0) continue;
            countLetters.add(new int[]{i, letters[i]});
        }
        countLetters.sort((a, b) -> b[1] - a[1]);
        if(S.length() % 2 == 0 && countLetters.get(0)[1] > S.length() / 2 ||
                S.length() % 2 != 0 && countLetters.get(0)[1] > S.length() / 2 + 1)
            return "";
        char[] res = new char[S.length()];
        int index = 0;
        for (int[] count : countLetters){
            while (count[1] != 0){
                res[index] = (char) (count[0] + 'a');
                index += 2;
                count[1]--;
                if(index >= S.length()) index = 1;
            }
        }
        return new String(res);
    }
}
