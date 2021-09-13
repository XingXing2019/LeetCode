package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        int[][] points = {{-2147483646, -2147483645}, {2147483646, 2147483647}};
        System.out.println(findMinArrowShots(points));
    }

    public static int findMinArrowShots(int[][] points) {
        Arrays.sort(points, (a, b) -> compare(a[0], b[0]));
        int right = points[0][1], res = 1;
        for (int[] point : points) {
            if (right >= point[0])
                right = Math.min(right, point[1]);
            else {
                res++;
                right = point[1];
            }
        }
        return res;
    }

    public static int compare(int a, int b){
        if(a >= b) return 1;
        return -1;
    }
}
