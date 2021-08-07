package com.company;

public class Main {

    public static void main(String[] args) {
        int[] nums = {1, 1};
        System.out.println(circularArrayLoop(nums));
    }

    public static boolean circularArrayLoop(int[] nums) {
        var nextVal = new int[nums.length];
        for (int i = 0; i < nums.length; i++) {
            var next = i + nums[i];
            if (next < 0) next = nums.length + next % nums.length;
            nextVal[i] = next % nums.length == i ? -nums[i] : nums[next % nums.length];
        }
        for (int i = 0; i < nums.length; i++) {
            if (nextVal[i] * nums[i] < 0) continue;
            var next = i + nums[i];
            var count = 0;
            while (next != i && count < nums.length) {
                if (next < 0) next = nums.length + next % nums.length;
                else if (next >= nums.length) next %= nums.length;
                if (nums[next] * nextVal[next] < 0)
                    break;
                if (next == i)
                    return true;
                next = next + nums[next];
                count++;
            }
        }
        return false;
    }
}
