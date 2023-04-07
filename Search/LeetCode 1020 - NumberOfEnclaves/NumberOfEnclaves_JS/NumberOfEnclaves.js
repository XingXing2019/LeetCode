/**
 * @param {number[][]} grid
 * @return {number}
 */
var numEnclaves = function (grid) {
    var m = grid.length, n = grid[0].length, res = 0
    for (let i = 0; i < m; i++) {
        if (grid[i][0] == 1)
            dfs(grid, i, 0)
        if (grid[i][n - 1] == 1)
            dfs(grid, i, n - 1)
    }
    for (let j = 0; j < n; j++) {
        if (grid[0][j] == 1)
            dfs(grid, 0, j)
        if (grid[m - 1][j] == 1)
            dfs(grid, m - 1, j)
    }
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (grid[i][j] != 1) continue
            res++
        }
    }
    return res
}

var dfs = function (grid, x, y) {
    if (x < 0 || x >= grid.length || y < 0 || y >= grid[0].length || grid[x][y] != 1)
        return
    grid[x][y] = 2
    dfs(grid, x + 1, y)
    dfs(grid, x - 1, y)
    dfs(grid, x, y + 1)
    dfs(grid, x, y - 1)
}