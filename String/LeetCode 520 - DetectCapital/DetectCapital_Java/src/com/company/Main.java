package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public boolean detectCapitalUse(String word) {
        int count = 0;
        for (int i = 0; i < word.length(); i++) {
            if (Character.isLowerCase(word.charAt(i))) continue;
            count++;
        }
        return count == 0 || count == word.length() || count == 1 && Character.isUpperCase(word.charAt(0));
    }
}
