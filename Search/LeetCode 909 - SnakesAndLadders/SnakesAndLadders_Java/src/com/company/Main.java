package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
        int[][] board = {{-1, -1, -1, -1, -1, -1}, {-1, -1, -1, -1, -1, -1}, {-1, -1, -1, -1, -1, -1}, {-1, 35, -1, -1, 13, -1}, {-1, -1, -1, -1, -1, -1}, {-1, 15, -1, -1, -1, -1}};
        //int[][] board = {{-1, -1}, {-1, 3}};
        System.out.println(snakesAndLadders(board));
    }

    public static int snakesAndLadders(int[][] board) {
        Map<Integer, int[]> map = new HashMap<>();
        int n = board.length, r = n - 1, c = 0;
        boolean increase = true;
        for (int i = 1; i <= n * n; i++) {
            map.put(i, new int[]{r, c});
            c = increase ? c + 1 : c - 1;
            if (c >= n || c < 0) {
                c = increase ? n - 1 : 0;
                increase = !increase;
                r--;
            }
        }
        HashSet<Integer> visited = new HashSet<>();
        visited.add(1);
        Queue<int[]> queue = new ArrayDeque<>();
        queue.offer(new int[]{1, 0});
        while (!queue.isEmpty()) {
            int[] cur = queue.poll();
            if (cur[0] == n * n) return cur[1];
            for (int i = 1; i <= 6 && cur[0] + i <= n * n; i++) {
                int next = cur[0] + i;
                int[] pos = map.get(next);
                if (board[pos[0]][pos[1]] == -1 && visited.add(next))
                    queue.offer(new int[]{next, cur[1] + 1});
                else if (board[pos[0]][pos[1]] != -1 && visited.add(board[pos[0]][pos[1]]))
                    queue.offer(new int[]{board[pos[0]][pos[1]], cur[1] + 1});
            }
        }
        return -1;
    }
}
