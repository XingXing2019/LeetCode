package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        int[][] people = new int[][]{
                new int[]{5, 2},
                new int[]{7, 0},
                new int[]{5, 0},
                new int[]{6, 1},
                new int[]{4, 4},
                new int[]{7, 1},
        };
        reconstructQueue(people);
    }
    public static int[][] reconstructQueue(int[][] people) {
        Arrays.sort(people, (a, b) -> a[0] == b[0] ? a[1] - b[1] : a[0] - b[0]);
        int[][] res = new int[people.length][];
        for (int[] p : people){
            int count = p[1];
            for (int i = 0; i < res.length; i++) {
                if(res[i] == null || res[i][0] >= p[0])
                    count--;
                if(count == -1){
                    res[i] = p;
                    break;
                }
            }
        }
        return res;
    }
}
