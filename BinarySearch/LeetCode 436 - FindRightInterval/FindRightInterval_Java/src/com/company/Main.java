package com.company;

import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int[] findRightInterval(int[][] intervals) {
        Map<int[], Integer> dict = new HashMap<>();
        for (int i = 0; i < intervals.length; i++)
            dict.put(intervals[i], i);
        var res = new int[intervals.length];
        Arrays.sort(intervals, (a, b) -> a[0] - b[0]);
        for (var i : intervals) {
            var interval = binarySearch(intervals, i[1]);
            res[dict.get(i)] = interval == null ? -1 : dict.get(interval);
        }
        return res;
    }

    public int[] binarySearch(int[][] intervals, int target) {
        int li = 0, hi = intervals.length - 1;
        while (li <= hi) {
            var mid = li + (hi - li) / 2;
            if (target <= intervals[mid][0])
                hi = mid - 1;
            else
                li = mid + 1;
        }
        return li >= intervals.length ? null : intervals[li];
    }
}
