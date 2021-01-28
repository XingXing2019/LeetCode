package com.company;

import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.HashSet;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int[] relativeSortArray(int[] arr1, int[] arr2) {
        HashMap<Integer, Integer> map = new HashMap<>();
        for (int num : arr1){
            if(!map.containsKey(num))
                map.put(num, 0);
            map.put(num, map.get(num) + 1);
        }
        int p1 = 0, p2 = 0;
        while (p2 < arr2.length){
            int count = map.get(arr2[p2]);
            for (int i = 0; i < count; i++)
                arr1[p1++] = arr2[p2];
            map.remove(arr2[p2++]);
        }
        ArrayList<Integer> left = new ArrayList<>();
        for (var kv : map.entrySet())
            left.add(kv.getKey());
        Collections.sort(left);
        for (int num : left){
            int count = map.get(num);
            for (int i = 0; i < count; i++)
                arr1[p1++] = num;
        }
        return arr1;
    }
}
