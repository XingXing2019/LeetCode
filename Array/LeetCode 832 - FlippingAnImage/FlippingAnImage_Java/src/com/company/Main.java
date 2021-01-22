package com.company;

import java.util.Collections;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int[][] flipAndInvertImage(int[][] A) {
        for (var row : A){
            int len = row.length % 2 == 0 ? row.length / 2 - 1 : row.length / 2;
            for (int i = 0; i <= len; i++) {
                var temp = row[i] ^ 1;
                row[i] = row[row.length - i - 1] ^ 1;
                row[row.length - i - 1] = temp;
            }
        }
        return A;
    }
}
