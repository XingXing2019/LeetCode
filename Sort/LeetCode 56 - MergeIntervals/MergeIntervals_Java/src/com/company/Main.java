package com.company;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int[][] merge(int[][] intervals) {
        Arrays.sort(intervals, (a, b) -> a[0] - b[0]);
        int li = intervals[0][0], hi = intervals[0][1];
        List<int[]> res = new ArrayList<>();
        for (int[] interval : intervals){
            if(li <= interval[0] && interval[0] <= hi)
                hi = Math.max(hi, interval[1]);
            else{
                res.add(new int[]{li , hi});
                li = interval[0];
                hi = interval[1];
            }
        }
        res.add(new int[]{li, hi});
        return res.toArray(new int[res.size()][]);
    }
}
