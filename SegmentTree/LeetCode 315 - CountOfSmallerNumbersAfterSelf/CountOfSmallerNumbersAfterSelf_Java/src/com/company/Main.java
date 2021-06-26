package com.company;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        int[] nums = {5, 2, 6, 1};
        System.out.println(countSmaller(nums));
    }
    public static List<Integer> countSmaller(int[] nums) {
        List<Integer> right = new ArrayList<>();
        Integer[] res = new Integer[nums.length];
        for (int i = nums.length - 1; i >= 0; i--) {
            int li = 0, hi = right.size() - 1;
            while (li <= hi){
                int mid = li + (hi - li) / 2;
                if(right.get(mid) < nums[i])
                    li = mid + 1;
                else
                    hi = mid - 1;
            }
            res[i] = li;
            right.add(li, nums[i]);
        }
        return Arrays.asList(res);
    }
}
