package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public boolean canMouseWin(String[] grid, int catJump, int mouseJump) {
        int cat = 0, mouse = 0;
        int[][][] dp = new int[70][grid.length + grid[0].length() * 10][grid.length + grid[0].length() * 10];
        for (int i = 0; i < grid.length; i++) {
            for (int j = 0; j < grid[0].length(); j++) {
                if (grid[i].charAt(j) == 'M')
                    mouse = i + 10 * j;
                else if (grid[i].charAt(j) == 'C')
                    cat = i + 10 * j;
            }
        }
        return dfs(grid, cat, mouse, catJump, mouseJump, 0, dp) == 1;
    }

    public int dfs(String[] grid, int cat, int mouse, int catJump, int mouseJump, int turn, int[][][] dp) {
        int catX = cat % 10, catY = cat / 10, mouseX = mouse % 10, mouseY = mouse / 10;
        if (grid[mouseX].charAt(mouseY) == 'F') return 1;
        if (turn >= 70 || grid[catX].charAt(catY) == 'F' || cat == mouse) return 2;
        if (dp[turn][cat][mouse] != 0) return dp[turn][cat][mouse];
        int[] dir = {1, 0, -1, 0, 1};
        if (turn % 2 == 0) {
            for (int i = 0; i < 4; i++) {
                for (int j = 0; j <= mouseJump; j++) {
                    int newX = mouseX + dir[i] * j, newY = mouseY + dir[i + 1] * j;
                    if (newX < 0 || newX >= grid.length || newY < 0 || newY >= grid[0].length() || grid[newX].charAt(newY) == '#')
                        break;
                    var next = dfs(grid, cat, newX + newY * 10, catJump, mouseJump, turn + 1, dp);
                    if (next == 1) return dp[turn][cat][mouse] = 1;
                }
            }
            dp[turn][cat][mouse] = 2;
        } else {
            for (int i = 0; i < 4; i++) {
                for (int j = 0; j <= catJump; j++) {
                    int newX = catX + dir[i] * j, newY = catY + dir[i + 1] * j;
                    if (newX < 0 || newX >= grid.length || newY < 0 || newY >= grid[0].length() || grid[newX].charAt(newY) == '#')
                        break;
                    var next = dfs(grid, newX + newY * 10, mouse, catJump, mouseJump, turn + 1, dp);
                    if (next == 2) return dp[turn][cat][mouse] = 2;
                }
            }
            dp[turn][cat][mouse] = 1;
        }
        return dp[turn][cat][mouse];
    }
}
