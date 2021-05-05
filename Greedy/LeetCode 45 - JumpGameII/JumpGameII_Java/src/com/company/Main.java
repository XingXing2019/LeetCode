package com.company;

public class Main {

    public static void main(String[] args) {
	    int[] nums = {1, 2, 3};
	    System.out.println(jump(nums));
    }
    public static int jump(int[] nums) {
        int reach = nums[0], cur = 0, res = 0;
        if(nums.length == 1) return res;
        while (reach < nums.length - 1){
            int jumpTo = 0;
            for (int i = cur; i <= cur + nums[cur] && i < nums.length; i++) {
                if(nums[i] + i > reach){
                    jumpTo = i;
                    reach = nums[i] + i;
                }
            }
            cur = jumpTo;
            res++;
        }
        return res + 1;
    }
}
