package com.company;

import java.lang.reflect.Array;
import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int smallestCommonElement(int[][] mat) {
        for (int num : mat[0]){
            boolean isCommon = true;
            for (int i = 0; i < mat.length; i++) {
                if(Arrays.binarySearch(mat[i], num) < 0){
                    isCommon = false;
                    break;
                }
            }
            if(isCommon) return num;
        }
        return -1;
    }
}
