package com.company;

import java.util.HashSet;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int[] prisonAfterNDays(int[] cells, int n) {
        int[][] status = new int[15][cells.length];
        status[0] = cells;
        for (int i = 1; i < status.length; i++) {
            int[] cur = new int[cells.length];
            for (int j = 1; j < cells.length - 1; j++)
                cur[j] = status[i - 1][j - 1] == status[i - 1][j + 1] ? 1 : 0;
            status[i] = cur;
        }
        return n % 14 == 0 ? status[status.length - 1] : status[n % 14];
    }
}
