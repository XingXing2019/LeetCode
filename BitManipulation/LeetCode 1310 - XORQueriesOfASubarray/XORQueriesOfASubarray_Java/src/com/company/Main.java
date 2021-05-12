package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int[] xorQueries(int[] arr, int[][] queries) {
        for (int i = 1; i < arr.length; i++)
            arr[i] ^= arr[i - 1];
        int[] res = new int[queries.length];
        for (int i = 0; i < queries.length; i++)
            res[i] = queries[i][0] == 0 ? arr[queries[i][1]] ^ 0 : arr[queries[i][1]] ^ arr[queries[i][0] - 1];
        return res;
    }
}
