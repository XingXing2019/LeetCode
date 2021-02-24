package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public boolean searchMatrix(int[][] matrix, int target) {
        int r = 0, c = matrix[0].length - 1;
        while (r < matrix.length && c >= 0){
            if(matrix[r][c] == target) return true;
            if(matrix[r][c] > target) c--;
            else r++;
        }
        return false;
    }
}
