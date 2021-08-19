package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int eraseOverlapIntervals(int[][] intervals) {
        Arrays.sort(intervals, (a, b) -> a[0] == b[0] ? a[1] - b[1] : a[0] - b[0]);
        int hi = intervals[0][1], res = 0;
        for (int i = 1; i < intervals.length; i++) {
            if (intervals[i][0] < hi && hi <= intervals[i][1])
                res++;
            else if (hi >= intervals[i][1]) {
                res++;
                hi = intervals[i][1];
            } else if (hi <= intervals[i][0])
                hi = intervals[i][1];
        }
        return res;
    }
}
