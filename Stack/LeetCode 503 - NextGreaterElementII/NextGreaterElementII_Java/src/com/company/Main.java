package com.company;

import java.util.Arrays;
import java.util.Stack;

public class Main {

    public static void main(String[] args) {
        int[] nums = {1, 2, 2};
        nextGreaterElements(nums);
    }
    public static int[] nextGreaterElements(int[] nums) {
        Stack<Integer> indexStack = new Stack<>();
        int[] res = new int[nums.length];
        Arrays.fill(res, -1);
        for (int i = 0; i < 2; i++) {
            for (int j = 0; j < nums.length; j++) {
                while (!indexStack.isEmpty() && nums[j] > nums[indexStack.peek()])
                    res[indexStack.pop()] = nums[j];
                indexStack.push(j);
            }
        }
        return res;
    }
}
