package com.company;

import java.util.Stack;

public class Main {

    public static void main(String[] args) {
        int[] heights = {2, 4};
        System.out.println(largestRectangleArea(heights));
    }

    public static int largestRectangleArea(int[] heights) {
        Stack<Integer> stack = new Stack<>();
        int res = 0;
        int[] left = new int[heights.length];
        for (int i = 0; i < heights.length; i++) {
            while (!stack.isEmpty() && heights[i] < heights[stack.peek()]) {
                int index = stack.pop();
                int len = i - index + left[index];
                res = Math.max(res, heights[index] * len);
                left[i] = len;
            }
            stack.push(i);
        }
        while (!stack.isEmpty()) {
            int index = stack.pop();
            int len = heights.length - index + left[index];
            res = Math.max(res, heights[index] * len);
        }
        return res;
    }
}
