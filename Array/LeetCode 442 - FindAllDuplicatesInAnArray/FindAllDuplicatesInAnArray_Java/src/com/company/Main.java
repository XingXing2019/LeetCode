package com.company;

import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public List<Integer> findDuplicates(int[] nums) {
        List<Integer> res = new ArrayList<>();
        for (Integer num : nums){
            int index = Math.abs(num) - 1;
            if (nums[index] < 0)
                res.add(Math.abs(num));
            nums[index] *= -1;
        }
        return res;
    }
}
