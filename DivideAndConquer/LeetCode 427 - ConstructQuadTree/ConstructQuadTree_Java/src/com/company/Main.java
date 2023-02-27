package com.company;

class Node {
    public boolean val;
    public boolean isLeaf;
    public Node topLeft;
    public Node topRight;
    public Node bottomLeft;
    public Node bottomRight;


    public Node() {
        this.val = false;
        this.isLeaf = false;
        this.topLeft = null;
        this.topRight = null;
        this.bottomLeft = null;
        this.bottomRight = null;
    }

    public Node(boolean val, boolean isLeaf) {
        this.val = val;
        this.isLeaf = isLeaf;
        this.topLeft = null;
        this.topRight = null;
        this.bottomLeft = null;
        this.bottomRight = null;
    }

    public Node(boolean val, boolean isLeaf, Node topLeft, Node topRight, Node bottomLeft, Node bottomRight) {
        this.val = val;
        this.isLeaf = isLeaf;
        this.topLeft = topLeft;
        this.topRight = topRight;
        this.bottomLeft = bottomLeft;
        this.bottomRight = bottomRight;
    }
}

public class Main {

    public static void main(String[] args) {
        int[][] grid = {{0, 1}, {1, 0}};
        System.out.println(construct(grid));
    }

    public static Node construct(int[][] grid) {
        return dfs(grid, 0, grid.length - 1, 0, grid[0].length - 1);
    }

    public static Node dfs(int[][] grid, int up, int down, int left, int right) {
        if (up > down || left > right)
            return null;
        if (allSame(grid, up, down, left, right))
            return new Node(grid[up][left] == 1, true);
        Node root = new Node(false, false);
        int half = (right - left + 1) / 2;
        root.topLeft = dfs(grid, up, up + half - 1, left, left + half - 1);
        root.topRight = dfs(grid, up, up + half - 1, left + half, right);
        root.bottomLeft = dfs(grid, up + half, down, left, left + half - 1);
        root.bottomRight = dfs(grid, up + half, down, left + half, right);
        return root;
    }

    public static boolean allSame(int[][] grid, int up, int down, int left, int right) {
        int val = grid[up][left];
        for (int i = up; i <= down; i++) {
            for (int j = left; j <= right; j++) {
                if (grid[i][j] == val) continue;
                return false;
            }
        }
        return true;
    }
}
