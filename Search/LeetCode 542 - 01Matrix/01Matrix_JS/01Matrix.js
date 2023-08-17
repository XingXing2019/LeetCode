/**
 * @param {number[][]} mat
 * @return {number[][]}
 */
var updateMatrix = function (mat) {
    var m = mat.length, n = mat[0].length
    var visited = new Array(m)
    var res = new Array(m)
    for (let i = 0; i < m; i++) {
        visited[i] = new Array(n).fill(false)
        res[i] = new Array(n).fill(0)
    }        
    var queue = []
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (mat[i][j] != 0) continue
            queue.push([i, j, 0])
            visited[i][j] = true
        }
    }
    var dir = [1, 0, -1, 0, 1]
    while (queue.length != 0) {
        var cur = queue.shift()
        res[cur[0]][cur[1]] = cur[2]
        for (let i = 0; i < 4; i++) {
            var newX = cur[0] + dir[i], newY = cur[1] + dir[i + 1]
            if (newX < 0 || newX >= m || newY < 0 || newY >= n || visited[newX][newY]) continue
            visited[newX][newY] = true
            queue.push([newX, newY, cur[2] + 1])
        }
    }
    return res
}