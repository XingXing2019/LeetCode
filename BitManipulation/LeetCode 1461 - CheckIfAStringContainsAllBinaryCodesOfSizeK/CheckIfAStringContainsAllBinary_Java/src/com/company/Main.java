package com.company;

import java.util.HashSet;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public boolean hasAllCodes(String s, int k) {
        HashSet<String> set = new HashSet<>();
        for (int i = 0; i <= s.length() - k; i++)
            set.add(s.substring(i, i + k));
        return set.size() == Math.pow(2, k);
    }
}
