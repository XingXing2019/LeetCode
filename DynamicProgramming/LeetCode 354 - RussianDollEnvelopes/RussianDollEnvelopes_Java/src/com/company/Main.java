package com.company;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;

public class Main {

    public static void main(String[] args) {
	    int[][] envelopes = {{6, 370}, {6, 360}, {7, 380}};
        System.out.println(maxEnvelopes(envelopes));
    }

    public static int maxEnvelopes(int[][] envelopes) {
        Arrays.sort(envelopes, (a, b) -> a[0] == b[0] ? b[1] - a[1] : a[0] - b[0]);
        List<Integer> tail = new ArrayList<>();
        for (int[] e : envelopes) {
            int index = binarySearch(tail, e[1]);
            if (index == tail.size())
                tail.add(e[1]);
            else
                tail.set(index, e[1]);
        }
        return tail.size();
    }

    public static int binarySearch(List<Integer> nums, int target) {
        int li = 0, hi = nums.size() - 1;
        while (li <= hi) {
            int mid = li + (hi - li) / 2;
            if (nums.get(mid) == target) return mid;
            if (nums.get(mid) < target) li = mid + 1;
            else hi = mid - 1;
        }
        return li;
    }
}
