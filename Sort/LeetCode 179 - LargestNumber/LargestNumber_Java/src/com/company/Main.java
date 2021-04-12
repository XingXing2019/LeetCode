package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        int[] nums = {3, 30, 34, 5, 9};
        System.out.println(largestNumber(nums));
    }

    public static String largestNumber(int[] nums) {
        if(Arrays.stream(nums).allMatch(a -> a == 0)) return "0";
        String[] res = new String[nums.length];
        for (int i = 0; i < nums.length; i++)
            res[i] = Integer.toString(nums[i]);
        Arrays.sort(res, (a, b) -> (int) (Double.parseDouble(b + a) - Double.parseDouble(a + b)));
        return String.join("", res);
    }
}
