package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public void rotate(int[] nums, int k) {
        k %= nums.length;
        int[] front = new int[k];
        for (int i = 0; i < front.length; i++)
            front[i] = nums[nums.length - k + i];
        int index = nums.length - 1;
        while (index - k >= 0){
            nums[index] = nums[index - k];
            index--;
        }
        while (index >= 0)
            nums[index--] = front[--k];
    }
}
