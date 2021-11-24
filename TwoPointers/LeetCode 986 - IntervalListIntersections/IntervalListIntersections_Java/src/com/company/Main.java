package com.company;

import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int[][] intervalIntersection(int[][] firstList, int[][] secondList) {
        int p1 = 0, p2 = 0, li = -1, hi = -1;
        boolean newInterval = false;
        List<int[]> inter = new ArrayList<>();
        while (p1 < firstList.length && p2 < secondList.length) {
            int[] i1 = firstList[p1], i2 = secondList[p2];
            if (i1[0] <= i2[0] && i2[0] <= i1[1] || i2[0] <= i1[0] && i1[0] <= i2[1]) {
                li = Math.max(i1[0], i2[0]);
                hi = Math.min(i1[1], i2[1]);
                newInterval = true;
            }
            if (newInterval) {
                inter.add(new int[]{li, hi});
                newInterval = false;
            }
            if (i1[1] < i2[1]) p1++;
            else p2++;
        }
        int[][] res = new int[inter.size()][];
        for (int i = 0; i < res.length; i++)
            res[i] = inter.get(i);
        return res;
    }
}
