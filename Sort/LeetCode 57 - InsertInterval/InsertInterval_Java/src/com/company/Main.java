package com.company;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int[][] insert(int[][] intervals, int[] newInterval) {
        List<int[]> temp = new ArrayList<>();
        boolean inserted = false;
        for (int[] interval : intervals) {
            if (interval[0] <= newInterval[0] && newInterval[0] <= interval[1])
                newInterval[0] = interval[0];
            if (interval[0] <= newInterval[1] && newInterval[1] <= interval[1])
                newInterval[1] = interval[1];
            if (!inserted && newInterval[1] < interval[0]) {
                temp.add(newInterval);
                inserted = true;
            }
            if (interval[1] < newInterval[0] || interval[0] > newInterval[1])
                temp.add(interval);
        }
        if (!inserted) temp.add(newInterval);
        int[][] res = new int[temp.size()][];
        temp.toArray(res);
        return res;
    }
}
