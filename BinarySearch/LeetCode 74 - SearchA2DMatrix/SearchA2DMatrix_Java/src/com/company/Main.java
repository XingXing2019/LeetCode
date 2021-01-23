package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public boolean searchMatrix(int[][] matrix, int target) {
        if(matrix.length == 1 || matrix[0][0] >= target)
            return Arrays.binarySearch(matrix[0], target) >= 0;
        int li = 0, hi = matrix.length - 1;
        while (li <= hi){
            int mid = li + (hi - li) / 2;
            if(matrix[mid][0] > target) hi = mid - 1;
            else li = mid + 1;
        }
        return Arrays.binarySearch(matrix[hi], target) >= 0;
    }
}
