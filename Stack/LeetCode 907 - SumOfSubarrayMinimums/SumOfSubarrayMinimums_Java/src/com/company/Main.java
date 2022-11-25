package com.company;

import java.util.Stack;

public class Main {

    public static void main(String[] args) {
        int[] arr = {1,5};
        System.out.println(sumSubarrayMins(arr));
    }

    public static int sumSubarrayMins(int[] arr) {
        long res = 0, mod = 1_000_000_000 + 7;
        Stack<Integer> stack = new Stack<>();
        for (int i = 0; i < arr.length; i++) {
            while (!stack.isEmpty() && arr[i] < arr[stack.peek()]) {
                int index = stack.pop();
                var left = stack.isEmpty() ? index + 1 : index - stack.peek();
                var right = i - index;
                res += (long) arr[index] * left * right;
            }
            stack.push(i);
        }
        while (!stack.isEmpty()) {
            var index = stack.pop();
            var left = stack.isEmpty() ? index + 1 : index - stack.peek();
            var right = arr.length - index;
            res += (long) arr[index] * left * right;
        }
        return (int) (res % mod);
    }
}
