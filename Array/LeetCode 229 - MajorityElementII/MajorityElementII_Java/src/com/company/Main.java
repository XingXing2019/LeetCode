package com.company;

import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public List<Integer> majorityElement(int[] nums) {
        int n1 = nums[0], n2 = 0, c1 = 1, c2 = 0;
        for (int i = 1; i < nums.length; i++) {
            if (nums[i] == n1)
                c1++;
            else if (nums[i] == n2)
                c2++;
            else if (c1 == 0) {
                n1 = nums[i];
                c1 = 1;
            } else if (c2 == 0) {
                n2 = nums[i];
                c2 = 1;
            } else {
                c1--;
                c2--;
            }
        }
        c1 = 0;
        c2 = 0;
        for (int num : nums) {
            if (num == n1)
                c1++;
            else if (num == n2)
                c2++;
        }
        List<Integer> res = new ArrayList<>();
        if (c1 > nums.length / 3)
            res.add(n1);
        if (c2 > nums.length / 3)
            res.add(n2);
        return res;
    }
}
