package com.company;

public class Main {

    public static void main(String[] args) {
        int num = 123;
        System.out.print(intToRoman(num));
    }

    public static String intToRoman(int num) {
        String[] romans = {"M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"};
        int[] nums = {1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1};
        String res = "";
        for (int i = 0; i < nums.length; i++) {
            var count = num / nums[i];
            if (count == 0) continue;
            for (int j = 0; j < count; j++)
                res += romans[i];
            num %= nums[i];
        }
        return res;
    }
}
