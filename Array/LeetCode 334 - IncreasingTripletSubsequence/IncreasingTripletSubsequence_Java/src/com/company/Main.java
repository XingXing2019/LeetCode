package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public boolean increasingTriplet(int[] nums) {
        int min = Integer.MAX_VALUE, secMin = Integer.MAX_VALUE;
        for (int num : nums) {
            if (num > secMin)
                return true;
            if (num < min)
                min = num;
            else if (min < num && num < secMin)
                secMin = num;
        }
        return false;
    }
}
