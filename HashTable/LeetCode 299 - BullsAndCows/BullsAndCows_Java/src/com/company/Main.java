package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public String getHint(String secret, String guess) {
        int[] digits = new int[10];
        int bull = 0, cow = 0;
        for (int i = 0; i < secret.length(); i++) {
            if(secret.charAt(i) == guess.charAt(i))
                bull++;
            digits[secret.charAt(i) - '0']++;
        }
        for (int i = 0; i < guess.length(); i++) {
            if(digits[guess.charAt(i) - '0'] > 0)
                cow++;
            digits[guess.charAt(i) - '0']--;
        }
        return bull + "A" + (cow - bull) + "B";
    }
}
