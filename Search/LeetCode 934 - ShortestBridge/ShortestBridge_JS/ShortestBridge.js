/**
 * @param {number[][]} grid
 * @return {number}
 */
var shortestBridge = function (grid) {
    var firstIsland = []
    for (let x = 0; x < grid.length; x++) {
        for (let y = 0; y < grid[0].length; y++) {
            if (grid[x][y] == 0) continue
            dfs(grid, x, y, firstIsland)      
            break
        }      
        if (firstIsland.length != 0)
            break
    }
    var visited = []
    for (let x = 0; x < grid.length; x++) {
        visited.push([])
        for (let y = 0; y < grid[0].length; y++)
            visited[x][y] = false
    }
    var queue = []
    firstIsland.forEach(x => {
        queue.push([x[0], x[1], 0])
        visited[x[0]][x[1]] = true
    })
    var dir = [1, 0, -1, 0, 1]
    while (queue.length != 0) {
        var cur = queue.shift()
        if (grid[cur[0]][cur[1]] == 1)
            return cur[2] - 1
        for (let i = 0; i < 4; i++) {
            var newX = cur[0] + dir[i], newY = cur[1] + dir[i + 1]
            if (newX < 0 || newX >= grid.length || newY < 0 || newY >= grid[0].length || visited[newX][newY])
                continue
            visited[newX][newY] = true
            queue.push([newX, newY, cur[2] + 1])
        }
    }
    return -1
}

var dfs = function (grid, x, y, firstIsland) {
    if (x < 0 || x >= grid.length || y < 0 || y >= grid[0].length || grid[x][y] != 1)
        return
    grid[x][y] = 2
    firstIsland.push([x, y])
    dfs(grid, x + 1, y, firstIsland)
    dfs(grid, x - 1, y, firstIsland)
    dfs(grid, x, y + 1, firstIsland)
    dfs(grid, x, y - 1, firstIsland)
}