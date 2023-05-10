/**
 * @param {number} n
 * @return {number[][]}
 */
var generateMatrix = function(n) {
    var res = [], visited = []
    for (let i = 0; i < n; i++) {
        res[i] = new Array(n)
        visited[i] = new Array(n).fill(false)
    }        
    var x = 0, y = 0, index = 0
    var dir = [[0, 1], [1, 0], [0, -1], [-1, 0]]
    for (let i = 1; i <= n * n; i++) {
        res[x][y] = i
        visited[x][y] = true
        var newX = x + dir[index % 4][0], newY = y + dir[index % 4][1]
        if (newX < 0 || newX >= n || newY < 0 || newY >= n || visited[newX][newY])
            index++
        x = x + dir[index % 4][0]
        y = y + dir[index % 4][1]
    }
    return res
}   