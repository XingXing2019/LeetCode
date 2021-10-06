package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public boolean canConstruct(String ransomNote, String magazine) {
        int[] letters = new int[26];
        for (Character l : magazine.toCharArray())
            letters[l - 'a']++;
        for (Character l : ransomNote.toCharArray()){
            letters[l - 'a']--;
            if(letters[l - 'a'] < 0)
                return false;
        }
        return true;
    }
}
