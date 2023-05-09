/**
 * @param {number[][]} matrix
 * @return {number[]}
 */
var spiralOrder = function(matrix) {
    var dir = [[0, 1], [1, 0], [0, -1], [-1, 0]]
    var index = 0, x = 0, y = 0, m = matrix.length, n = matrix[0].length
    var res = []
    var visited = new Array(m)
    for (let i = 0; i < m; i++)
        visited[i] = new Array(n).fill(false)
    for (let i = 0; i < m * n; i++) {
        res.push(matrix[x][y])
        visited[x][y] = true
        var newX = x + dir[index % 4][0], newY = y + dir[index % 4][1]
        if (newX < 0 || newX >= m || newY < 0 || newY >= n || visited[newX][newY]) {
            index++
            newX = x + dir[index % 4][0]
            newY = y + dir[index % 4][1]
        }
        x = newX
        y = newY
    }
    return res
}