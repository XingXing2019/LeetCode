package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public boolean[] canEat(int[] candiesCount, int[][] queries) {
        long[] prefix = new long[candiesCount.length + 1];
        for (int i = 1; i < prefix.length; i++)
            prefix[i] = candiesCount[i - 1] + prefix[i - 1];
        boolean[] res = new boolean[queries.length];
        for (int i = 0; i < queries.length; i++) {
            long min = queries[i][1], max = ((long) queries[i][1] + 1) * queries[i][2];
            if (min < prefix[queries[i][0] + 1] && max > prefix[queries[i][0]])
                res[i] = true;
        }
        return res;
    }
}
