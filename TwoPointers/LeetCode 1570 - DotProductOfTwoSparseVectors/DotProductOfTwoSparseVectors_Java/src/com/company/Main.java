package com.company;

import java.util.HashMap;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
}

class SparseVector {
    public Map<Integer, Integer> nonZero;
    SparseVector(int[] nums) {
        nonZero = getNonZero(nums);
    }

    public int dotProduct(SparseVector vec) {
        int res = 0;
        for (int index : this.nonZero.keySet()) {
            if (!vec.nonZero.containsKey(index)) continue;
            res += this.nonZero.get(index) * vec.nonZero.get(index);
        }
        return res;
    }

    private Map<Integer, Integer> getNonZero(int[] nums) {
        Map<Integer, Integer> map = new HashMap<>();
        for (int i = 0; i < nums.length; i++) {
            if (nums[i] == 0) continue;
            map.put(i, nums[i]);
        }
        return map;
    }
}
