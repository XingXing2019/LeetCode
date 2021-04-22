package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int missingNumber(int[] arr) {
        return (arr[0] + arr[arr.length - 1]) * (arr.length + 1) / 2 - Arrays.stream(arr).sum();
    }
}
