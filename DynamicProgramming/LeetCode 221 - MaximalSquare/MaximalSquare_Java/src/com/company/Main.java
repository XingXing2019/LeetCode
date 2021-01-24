package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int maximalSquare(char[][] matrix) {
        int len = 0;
        for (int i = 0; i < matrix.length; i++)
            len = Math.max(len, matrix[i][0] - '0');
        for (int i = 0; i < matrix[0].length; i++)
            len = Math.max(len, matrix[0][i] - '0');
        for (int i = 1; i < matrix.length; i++) {
            for (int j = 1; j < matrix[0].length; j++) {
                if(matrix[i][j] == '0') continue;
                matrix[i][j] = (char) (Math.min(matrix[i - 1][j - 1], Math.min(matrix[i - 1][j], matrix[i][j - 1])) + 1);
                len = Math.max(len, matrix[i][j] - '0');
            }
        }
        return len * len;
    }
}
