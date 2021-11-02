/**
 * @param {number[][]} grid
 * @return {number}
 */
 var uniquePathsIII = function (grid) {
    let x = 0, y = 0, count = 0, path = 0;
    let visited = [];
    for (let i = 0; i < grid.length; i++) {
        visited[i] = new Array(grid[0].length);
        for (let j = 0; j < grid[0].length; j++) {
            if (grid[i][j] == 1){
                x = i;
                y = j;
            }
            else if (grid[i][j] == 0)
                count++;
        }        
    }
    const dfs = function (grid, x, y, visited, count) {
        if (x < 0 || x >= grid.length || y < 0 || y >= grid[0].length || visited[x][y] || grid[x][y] == -1){
            count++;
            return;
        }
        if (grid[x][y] == 2) count++;
        visited[x][y] = true;
        if (grid[x][y] == 2 && count == 0)
            path++;
        dfs(grid, x + 1, y, visited, count - 1);
        dfs(grid, x - 1, y, visited, count - 1);
        dfs(grid, x, y + 1, visited, count - 1);
        dfs(grid, x, y - 1, visited, count - 1);
        visited[x][y] = false;
    }
    dfs(grid, x, y, visited, count);
    return path;
};