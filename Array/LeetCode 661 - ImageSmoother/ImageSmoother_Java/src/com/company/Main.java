package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int[][] imageSmoother(int[][] img) {
        int[] dx = {-1, 1, 0, 0, -1, 1, -1, 1};
        int[] dy = {0, 0, -1, 1, -1, -1, 1, 1};
        int[][] res = new int[img.length][img[0].length];
        for (int x = 0; x < img.length; x++) {
            for (int y = 0; y < img[0].length; y++) {
                int count = 1, sum = img[x][y];
                for (int i = 0; i < 8; i++) {
                    int newX = x + dx[i], newY = y + dy[i];
                    if (newX < 0 || newX >= img.length || newY < 0 || newY >= img[0].length)
                        continue;
                    count++;
                    sum += img[newX][newY];
                }
                res[x][y] = sum / count;
            }
        }
        return res;
    }
}
