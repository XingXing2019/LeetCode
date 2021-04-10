package com.company;

import java.util.Arrays;
import java.util.PriorityQueue;

class GridMaster {
      boolean canMove(char direction) {return true;};
      int move(char direction) {return 0;};
      boolean isTarget() {return true;};
  }

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int findShortestPath(GridMaster master) {
        char[] dir = {'R', 'D', 'L', 'U'};
        int[] coordinate = {0, 1, 0, -1, 0};
        int[][] map = new int[201][201];
        Arrays.fill(map, -1);
        dfs(master, map, dir, coordinate, 100, 100);
        PriorityQueue<int[]> heap = new PriorityQueue<>();
        heap.offer(new int[]{100, 100, 0});
        int res = 0;
        while (!heap.isEmpty()){
            int[] cur = heap.poll();
            if(map[cur[0]][cur[1]] == -2)
                return res;
            res += cur[2];
            for (int i = 0; i < 4; i++) {
                int newX = cur[0] + coordinate[i];
                int newY = cur[1] + coordinate[i + 1];
                if(newX < 0 || newX >= map.length || newY < 0 || newY >= map[0].length || map[newX][newY] == -1)
                    continue;
                heap.offer(new int[]{newX, newY, map[newX][newY]});
            }
        }
        return -1;
    }
    public static void dfs(GridMaster master, int[][] map, char[] dir, int[] coordinate, int x, int y){
        if(master.isTarget()){
            map[x][y] = -2;
            return;
        }
        for (int i = 0; i < dir.length; i++) {
            if(master.canMove(dir[i])){
                int newX = x + coordinate[i];
                int newY = y + coordinate[i + 1];
                if(newX < 0 || newX >= map.length || newY < 0 || newY >= map[0].length)
                    continue;
                map[x][y] = master.move(dir[i]);
                dfs(master, map, dir, coordinate, newX, newY);
            }
        }
    }
}
