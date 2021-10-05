package com.company;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int[] intersect(int[] nums1, int[] nums2) {
        Map<Integer, Integer> map = new HashMap<>();
        for (Integer num : nums1)
            map.put(num, map.getOrDefault(num, 0) + 1);
        List<Integer> temp = new ArrayList<>();
        for (Integer num : nums2){
            if (!map.containsKey(num)) continue;
            temp.add(num);
            map.put(num, map.get(num) - 1);
            if(map.get(num) == 0)
                map.remove(num);
        }
        int[] res = new int[temp.size()];
        for (int i = 0; i < res.length; i++)
            res[i] = temp.get(i);
        return res;
    }
}
