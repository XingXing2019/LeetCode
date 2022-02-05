/**
 * @param {number[][]} grid
 * @return {number}
 */
var getMaximumGold = function (grid) {
    var dfs = function (x, y, visited) {
        if (x < 0 || x >= grid.length || y < 0 || y >= grid[0].length || grid[x][y] == 0 || visited[x][y])
            return 0
        var res = grid[x][y]
        visited[x][y] = true
        var max = 0
        max = Math.max(max, dfs(x + 1, y, visited))
        max = Math.max(max, dfs(x - 1, y, visited))
        max = Math.max(max, dfs(x, y + 1, visited))
        max = Math.max(max, dfs(x, y - 1, visited))
        visited[x][y] = false
        return res + max
    }
    var res = 0
    for (let x = 0; x < grid.length; x++) {
        for (let y = 0; y < grid[0].length; y++) {
            var visited = []
            for (let i = 0; i < grid.length; i++) 
                visited[i] = []
            res = Math.max(res, dfs(x, y, visited))            
        }        
    }
    return res
}
