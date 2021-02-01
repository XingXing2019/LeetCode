package com.company;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

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
        Arrays.sort(people, (a, b) -> a[0] == b[0] ? a[1] - b[1] : b[0] - a[0]);
        List<int[]> res = new ArrayList<>();
        for (int[] p : people)
            res.add(p[1], p);
        return res.toArray(new int[people.length][]);
    }
}
