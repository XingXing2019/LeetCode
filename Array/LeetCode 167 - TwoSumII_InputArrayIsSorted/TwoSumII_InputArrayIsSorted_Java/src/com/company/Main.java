package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int[] twoSum(int[] numbers, int target) {
        for (int i = 0; i < numbers.length; i++) {
            int index = binarySearch(numbers, i + 1, numbers.length - 1, target - numbers[i]);
            if (index == -1) continue;
            return new int[] {i + 1, index + 1};
        }
        return null;
    }

    public int binarySearch(int[] number, int li, int hi, int target) {
        while (li <= hi) {
            int mid = li + (hi - li) / 2;
            if (number[mid] == target)
                return mid;
            if (number[mid] > target)
                hi = mid - 1;
            else
                li = mid + 1;
        }
        return -1;
    }
}
