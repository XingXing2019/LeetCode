/**
 * @param {number[][]} grid
 * @param {number} row
 * @param {number} col
 * @param {number} color
 * @return {number[][]}
 */
var colorBorder = function (grid, row, col, color) {
    var m = grid.length, n = grid[0].length;
    var dfs = function(grid, x, y, visited, oldColor) {
        if (x < 0 || x >= m || y < 0 || y >= n)
            return;
        if (visited[x][y] || Math.abs(grid[x][y]) != oldColor)
            return;
        visited[x][y] = true;
        if (x == 0 || x == m - 1 || y == 0 || y == n - 1 ||
            Math.abs(grid[x - 1][y]) != oldColor || Math.abs(grid[x + 1][y]) != oldColor ||
            Math.abs(grid[x][y - 1]) != oldColor || Math.abs(grid[x][y + 1]) != oldColor)
            grid[x][y] = -oldColor;
        dfs(grid, x + 1, y, visited, oldColor);
        dfs(grid, x - 1, y, visited, oldColor);
        dfs(grid, x, y + 1, visited, oldColor);
        dfs(grid, x, y - 1, visited, oldColor);
    }
    var visited = [];
    for (let i = 0; i < grid.length; i++)
        visited[i] = [];
    dfs(grid, row, col, visited, grid[row][col]);
    for (let i = 0; i < grid.length; i++) {
        for (let j = 0; j < grid[0].length; j++) {
            if (grid[i][j] < 0)
                grid[i][j] = color;
        }        
    }
    return grid;
};