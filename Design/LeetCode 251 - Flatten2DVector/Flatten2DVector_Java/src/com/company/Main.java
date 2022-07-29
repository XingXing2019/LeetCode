package com.company;

import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
}

class Vector2D {
    List<Integer> nums;
    int index;
    public Vector2D(int[][] vec) {
        nums = new ArrayList<>();
        for (int[] row : vec) {
            for (int num : row) {
                nums.add(num);
            }
        }
    }

    public int next() {
        return nums.get(index++);
    }

    public boolean hasNext() {
        return index != nums.size();
    }
}
