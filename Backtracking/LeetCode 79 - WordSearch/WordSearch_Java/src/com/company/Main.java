package com.company;

public class Main {

    public static void main(String[] args) {
        char[][] board = new char[][]{
                new char[]{'A', 'B'},
                new char[]{'S', 'F'},
        };
        String word = "AB";
        System.out.print(exist(board, word));
    }

    public static boolean exist(char[][] board, String word) {
        for (int x = 0; x < board.length; x++) {
            for (int y = 0; y < board[0].length; y++) {
                if (board[x][y] != word.charAt(0)) continue;
                int[][] mark = new int[board.length][];
                for (int i = 0; i < board.length; i++)
                    mark[i] = new int[board[0].length];
                if (DFS(board, mark, x, y, 0,"", word))
                    return true;
            }
        }
        return false;
    }

    public static boolean DFS(char[][] borad, int[][] mark, int x, int y, int cur, String path, String word) {
        if (x < 0 || x >= borad.length || y < 0 || y >= borad[0].length || mark[x][y] == 1 || word.charAt(cur) != borad[x][y])
            return false;
        path += borad[x][y];
        mark[x][y] = 1;
        if (path.equals(word)) return true;
        boolean res = false;
        res = res || DFS(borad, mark, x + 1, y, cur + 1, path, word);
        res = res || DFS(borad, mark, x - 1, y, cur + 1, path, word);
        res = res || DFS(borad, mark, x, y + 1, cur + 1, path, word);
        res = res || DFS(borad, mark, x, y - 1, cur + 1, path, word);
        mark[x][y] = 0;
        return res;
    }
}
