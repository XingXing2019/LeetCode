package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int maxArea(int[] height) {
        int li = 0, hi = height.length - 1, res = 0;
        while (li < hi){
            res = Math.max(res, Math.min(height[li], height[hi]) * (hi - li));
            if(height[li] < height[hi])
                li++;
            else
                hi--;
        }
        return res;
    }
}
