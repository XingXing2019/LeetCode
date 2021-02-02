package com.company;

import java.util.Arrays;
import java.util.HashSet;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public String reverseVowels(String s) {
        char[] letters = s.toCharArray();
        HashSet<Character> vowels = new HashSet<>(Arrays.asList('a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'));
        int li = 0, hi = letters.length - 1;
        while (li < hi) {
            if (vowels.contains(letters[li]) && vowels.contains(letters[hi])) {
                char temp = letters[li];
                letters[li++] = letters[hi];
                letters[hi--] = temp;
            } else if (!vowels.contains(letters[li]))
                li++;
            else if (!vowels.contains(letters[hi]))
                hi--;
        }
        return new String(letters);
    }
}
