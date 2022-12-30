package com.company;

import java.util.List;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    interface BinaryMatrix {
        int get(int row, int col);
        List<Integer> dimensions();
    }

    public int leftMostColumnWithOne(BinaryMatrix binaryMatrix) {
        var dimensions = binaryMatrix.dimensions();
        int m = dimensions.get(0), n = dimensions.get(1);
        int res = n;
        for (int i = 0; i < m; i++) {
            int li = 0, hi = n - 1;
            while (li <= hi) {
                int j = li + (hi - li) / 2;
                if (binaryMatrix.get(i, j) == 0)
                    li = j + 1;
                else
                    hi = j - 1;
            }
            res = Math.min(res, li);
        }
        return res == n ? -1 : res;
    }
}
