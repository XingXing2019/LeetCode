package com.company;

import java.util.HashMap;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int numIdenticalPairs_HashMap(int[] nums) {
        HashMap<Integer, Integer> map = new HashMap<>();
        int res = 0;
        for (int num: nums) {
            if(map.containsKey(num)){
                res += map.get(num);
                map.put(num, map.get(num) + 1);
            }
            else
                map.put(num, 1);
        }
        return res;
    }
}
