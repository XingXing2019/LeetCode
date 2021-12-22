/**
 * @param {character[][]} grid
 * @return {number}
 */
var numIslands = function (grid) {
    var dfs = function(x, y) {
        if (x < 0 || x >= grid.length || y < 0 || y >= grid[0].length || grid[x][y] != '1')
            return;
        grid[x][y] = '0';
        dfs(x + 1, y);
        dfs(x - 1, y);
        dfs(x, y + 1);
        dfs(x, y - 1);
    }
    var res = 0;
    for (let x = 0; x < grid.length; x++) {
        for (let y = 0; y < grid[0].length; y++) {
            if (grid[x][y] === '0') continue;
            dfs(x, y);
            res++
        }        
    }
    return res;
};