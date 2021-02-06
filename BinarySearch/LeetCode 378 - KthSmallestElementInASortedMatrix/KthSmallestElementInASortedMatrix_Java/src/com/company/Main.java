package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int kthSmallest(int[][] matrix, int k) {
        int n = matrix.length, m = matrix[0].length;
        int li = matrix[0][0], hi = matrix[n - 1][m - 1];
        while (li <= hi){
            int mid = li + (hi - li) / 2;
            int smaller = 0;
            for(int[] row : matrix){
                int index = Arrays.binarySearch(row, mid);
                smaller += index < 0 ? ~index : index;
            }
            if(smaller > k - 1) hi = mid - 1;
            else li = mid + 1;
        }
        return hi;
    }
}
