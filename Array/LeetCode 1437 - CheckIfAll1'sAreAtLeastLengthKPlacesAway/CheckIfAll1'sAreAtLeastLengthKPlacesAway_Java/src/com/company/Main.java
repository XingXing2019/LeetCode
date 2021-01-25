package com.company;

import java.util.ArrayList;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public boolean kLengthApart_ArrayList(int[] nums, int k) {
        ArrayList<Integer> index = new ArrayList<>();
        for (int i = 0; i < nums.length; i++) {
            if(nums[i] == 1)
                index.add(i);
        }
        if(index.size() == 0) return true;
        for (int i = 1; i < index.size(); i++) {
            if(index.get(i) - index.get(i - 1) < k + 1)
                return false;
        }
        return true;
    }
}
