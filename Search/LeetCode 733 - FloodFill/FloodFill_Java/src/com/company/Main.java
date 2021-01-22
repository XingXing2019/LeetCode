package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int[][] floodFill(int[][] image, int sr, int sc, int newColor) {
        if(image.length == 0 || image[0].length == 0) return image;
        var mark = new int[image.length][];
        for (int i = 0; i < mark.length; i++)
            mark[i] = new int[image[0].length];
        DFS(image, mark, sr, sc, image[sr][sc], newColor);
        return image;
    }
    public static void DFS(int[][] image, int[][] mark, int x, int y, int color, int newColor){
        mark[x][y] = 1;
        image[x][y] = newColor;
        int[] dx = {-1, 1, 0, 0};
        int[] dy = {0, 0, -1, 1};
        for (int i = 0; i < 4; i++) {
            int newX = x + dx[i];
            int newY = y + dy[i];
            if(newX < 0 || newX >= image.length || newY < 0 || newY >= image[0].length)
                continue;
            if(mark[newX][newY] == 0 && image[newX][newY] == color)
                DFS(image, mark, newX, newY, color, newColor);
        }
    }
}
