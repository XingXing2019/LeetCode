package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public boolean reorderedPowerOf2(int N) {
        int[] powers = new int[30];
        powers[0] = 1;
        powers[1] = 2;
        for (int i = 2; i < powers.length; i++)
            powers[i] = powers[i - 1] * 2;
        for (int power : powers){
            if(check(Integer.toString(power), Integer.toString(N)))
                return true;
        }
        return false;
    }

    private boolean check(String num1, String num2) {
        if(num1.length() != num2.length())
            return false;
        int[] digits = new int[10];
        for (int i = 0; i < num1.length(); i++) {
            digits[num1.charAt(i) - '0']++;
            digits[num2.charAt(i) - '0']--;
        }
        for (int i = 0; i < digits.length; i++) {
            if(digits[i] != 0)
                return false;
        }
        return true;
    }
}
