package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public String generateTheString(int n) {
        String[] letters = new String[n];
        Arrays.fill(letters, "a");
        if(n % 2 == 0) letters[0] = "b";
        return String.join("", letters);
    }
}
