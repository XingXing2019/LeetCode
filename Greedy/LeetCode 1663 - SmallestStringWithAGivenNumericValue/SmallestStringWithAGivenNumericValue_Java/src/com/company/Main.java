package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
	    int n = 3, k = 27;
	    System.out.println(getSmallestString(n, k));
    }

    public static String getSmallestString(int n, int k) {
        char[] letters = new char[n];
        Arrays.fill(letters, 'a');
        k -= n;
        for (int i = n - 1; i >= 0 && k > 0; i--) {
            letters[i] += Math.min(k, 25);
            k -= 25;
        }
        return new String(letters);
    }
}
