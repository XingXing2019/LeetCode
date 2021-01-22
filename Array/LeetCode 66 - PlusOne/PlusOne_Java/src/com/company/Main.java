package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int[] plusOne(int[] digits) {
        digits[digits.length - 1]++;
        int car = 0, cur = 0;
        for (int i = digits.length - 1; i >= 0; i--) {
            cur = (digits[i] + car) % 10;
            car = (digits[i] + car) / 10;
            digits[i] = cur;
        }
        if(car == 0) return digits;
        var res = new int[digits.length + 1];
        res[0] = 1;
        for (int i = 1; i < res.length; i++)
            res[i] = digits[i - 1];
        return res;
    }
}
