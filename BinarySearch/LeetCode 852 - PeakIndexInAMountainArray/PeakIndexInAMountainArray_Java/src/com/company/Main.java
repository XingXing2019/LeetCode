package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int peakIndexInMountainArray(int[] arr) {
        for (int i = 0; i < arr.length; i++) {
            if(arr[i] > arr[i + 1])
                return i;
        }
        return -1;
    }
}
