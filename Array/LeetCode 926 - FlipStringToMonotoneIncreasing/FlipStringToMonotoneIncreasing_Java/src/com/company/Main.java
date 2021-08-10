package com.co
mpany;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int minFlipsMonoIncr(String s) {
        int[] leftOne = new int[s.length()], rightZero = new int[s.length()];
        int one = 0, zero = 0;
        for (int i = 0; i < s.length(); i++) {
            leftOne[i] = one;
            if(s.charAt(i) == '1') one++;
            rightZero[s.length() - i - 1] = zero;
            if(s.charAt(s.length() - i - 1) == '0') zero++;
        }
        int res = Integer.MAX_VALUE;
        for (int i = 0; i < s.length(); i++)
            res = Math.min(res, leftOne[i] + rightZero[i]);
        return res;
    }
}
