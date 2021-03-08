package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public boolean isRobotBounded(String instructions) {
        int x = 0, y = 0;
        int[][] dir = {{0, -1}, {-1, 0}, {0, 1}, {1, 0}};
        int index = 0;
        for (Character i : instructions.toCharArray()) {
            if (i == 'G') {
                x += dir[index][0];
                y += dir[index][1];
            } else if (i == 'L') {
                index--;
                if(index < 0) index = 3;
            } else {
                index++;
                if(index > 3) index = 0;
            }
        }
        return x == 0 && y == 0 || index != 0;
    }
}
