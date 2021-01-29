package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int numRookCaptures(char[][] board) {
        int[] rook = new int[2];
        for (int x = 0; x < board.length; x++) {
            for (int y = 0; y < board[0].length; y++) {
                if(board[x][y] == 'R'){
                    rook[0] = x;
                    rook[1] = y;
                    break;
                }
            }
        }
        int[] dir = {0, 1, 0, -1, 0};
        int res = 0;
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 8; j++) {
                int newX = rook[0] + dir[i] * j;
                int newY = rook[1] + dir[i + 1] * j;
                if(newX < 0 || newX >= board.length || newY < 0 || newY >= board[0].length || board[newX][newY] == 'B')
                    break;
                if(board[newX][newY] == 'p'){
                    res++;
                    break;
                }
            }
        }
        return res;
    }
}
