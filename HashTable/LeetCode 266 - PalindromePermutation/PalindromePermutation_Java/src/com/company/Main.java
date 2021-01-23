package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public boolean canPermutePalindrome(String s) {
        int[] record = new int[128];
        for (char l : s.toCharArray())
            record[l]++;
        int count = 0;
        for (int i : record)
            count += i % 2 == 0 ? 0 : 1;
        return count < 2;
    }
}
