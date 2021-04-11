package com.company;

import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
        int[] obstacles = {0,1,0,2,3,1,2,3,3,2,0};
        minSideJumps(obstacles);
    }
    public static int minSideJumps(int[] obstacles) {
        PriorityQueue<int[]> minHeap = new PriorityQueue<>((a, b) -> a[2] - b[2]);
        minHeap.offer(new int[]{0, 2, 0});
        int[] dir = {-2, -1, 1, 2};
        while (!minHeap.isEmpty()){
            int[] cur = minHeap.poll();
            if(cur[0] == obstacles.length - 1)
                return cur[2];
            int nextX = cur[0] + 1;
            if(obstacles[nextX] != cur[1])
                minHeap.offer(new int[]{nextX, cur[1], cur[2]});
            else{
                for (int i = 0; i < 4; i++) {
                    int nextY = cur[1] + dir[i];
                    if(nextY < 1 || nextY > 3 || obstacles[cur[0]] == nextY) continue;
                    minHeap.offer(new int[]{cur[0], nextY, cur[2] + 1});
                }
            }
        }
        return -1;
    }
}
