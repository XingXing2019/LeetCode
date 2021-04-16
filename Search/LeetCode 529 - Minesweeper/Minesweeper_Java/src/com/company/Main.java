package com.company;

import java.util.ArrayDeque;
import java.util.Queue;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public char[][] updateBoard(char[][] board, int[] click) {
        if(board[click[0]][click[1]] == 'M'){
            board[click[0]][click[1]] = 'X';
            return board;
        }
        int[] dx = {-1, 1, 0, 0, -1, 1, -1, 1};
        int[] dy = {0, 0, -1, 1, -1, -1, 1, 1};
        Queue<int[]> queue = new ArrayDeque<>();
        queue.offer(click);
        boolean[][] visited = new boolean[board.length][board[0].length];
        visited[click[0]][click[1]] = true;
        while (!queue.isEmpty()){
            var cur = queue.poll();
            int count = checkMines(board, cur, dx, dy);
            board[cur[0]][cur[1]] = count == 0 ? 'B' : (char) (count + '0');
            if(count != 0) continue;
            for (int i = 0; i < 8; i++) {
                int newX = cur[0] + dx[i];
                int newY = cur[1] + dy[i];
                if(newX < 0 || newX >= board.length || newY < 0 || newY >= board[0].length || visited[newX][newY])
                    continue;
                visited[newX][newY] = true;
                queue.offer(new int[]{newX, newY});
            }
        }
        return board;
    }
    public int checkMines(char[][] board, int[] cur, int[] dx, int[] dy){
        int count = 0;
        for (int i = 0; i < 8; i++) {
            int newX = cur[0] + dx[i];
            int newY = cur[1] + dy[i];
            if(newX >= 0 && newX < board.length && newY >= 0 && newY < board[0].length && board[newX][newY] == 'M')
                count++;
        }
        return count;
    }
}
