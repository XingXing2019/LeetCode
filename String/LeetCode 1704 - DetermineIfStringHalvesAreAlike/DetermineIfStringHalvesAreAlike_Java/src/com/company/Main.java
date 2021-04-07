package com.company;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashSet;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public boolean halvesAreAlike(String s) {
        HashSet<Character> vowels = new HashSet<>(Arrays.asList('a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'));
        int count = 0;
        for (int i = 0; i < s.length() / 2; i++) {
            if(vowels.contains(s.charAt(i)))
                count++;
            if(vowels.contains(s.charAt(s.length() - i - 1)))
                count--;
        }
        return count == 0;
    }
}
