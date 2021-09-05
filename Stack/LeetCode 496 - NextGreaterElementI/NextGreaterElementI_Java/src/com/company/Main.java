package com.company;

import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;
import java.util.Stack;

public class Main {

    public static void main(String[] args) {
	    int[] nums1 = {4, 1, 2}, nums2 = {1, 3, 4, 2};
        System.out.println(nextGreaterElement(nums1, nums2));
    }
    public static int[] nextGreaterElement(int[] nums1, int[] nums2) {
        Map<Integer, Integer> map = new HashMap<>();
        for (int i = 0; i < nums2.length; i++)
            map.put(nums2[i], i);
        Stack<Integer> stack = new Stack<>();
        int[] record = new int[nums2.length];
        Arrays.fill(record, -1);
        for (int i = 0; i < nums2.length; i++) {
            while (!stack.isEmpty() && nums2[i] > nums2[stack.peek()])
                record[stack.pop()] = i;
            stack.push(i);
        }
        for (int i = 0; i < nums1.length; i++) {
            int index = map.get(nums1[i]);
            nums1[i] = record[index] == -1 ? -1 : nums2[record[index]];
        }
        return nums1;
    }
}
