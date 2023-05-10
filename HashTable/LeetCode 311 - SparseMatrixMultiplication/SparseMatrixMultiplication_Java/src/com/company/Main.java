package com.company;

public class Main {

    public static void main(String[] args) {
        int[][] mat1 = {{1, 0, 0, 1}, {-1, 0, 3, 4}};
        int[][] mat2 = {{7, 0, 0, 5, 5}, {0, 0, 0, 6, 4}, {0, 0, 1, 7, 3}, {3, 4, 5, 2, 4}};
        System.out.println(multiply(mat1, mat2));
    }

    public static int[][] multiply(int[][] mat1, int[][] mat2) {
        int[][] res = new int[mat1.length][mat2[0].length];
        int[][] temp = new int[mat2[0].length][mat2.length];
        for (int j = 0; j < mat2[0].length; j++) {
            for (int i = 0; i < mat2.length; i++) {
                temp[j][i] = mat2[i][j];
            }
        }
        for (int i = 0; i < res.length; i++) {
            for (int j = 0; j < res[0].length; j++) {
                res[i][j] = calc(mat1[i], temp[j]);
            }
        }
        return res;
    }

    public static int calc(int[] nums1, int[] nums2){
        int res = 0;
        for (int i = 0; i < nums1.length; i++)
            res += nums1[i] * nums2[i];
        return res;
    }
}
