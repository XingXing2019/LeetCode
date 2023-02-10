/**
 * @param {number[][]} grid
 * @return {number}
 */
var maxDistance = function (grid) {
    var n = grid.length
    var queue = []
    var visited = new Array(n)
    for (let i = 0; i < n; i++) {
        visited[i] = new Array(n).fill(false)
        for (let j = 0; j < n; j++) {
            if (grid[i][j] == 0) continue
            queue.push([i, j])
            visited[i][j] = true
        }
    }
    if (queue.length == 0 || queue.length == n * n)
        return -1
    var level = -1
    var dir = [1, 0, -1, 0, 1]
    while (queue.length != 0) {
        var count = queue.length
        for (let i = 0; i < count; i++) {            
            var cur = queue.shift()
            for (let j = 0; j < 4; j++) {
                var newX = dir[j] + cur[0]
                var newY = dir[j + 1] + cur[1]
                if (newX < 0 || newX >= n || newY < 0 || newY >= n || visited[newX][newY])
                    continue
                visited[newX][newY] = true
                queue.push([newX, newY])
            }
        }        
        level++
    }
    return level
}