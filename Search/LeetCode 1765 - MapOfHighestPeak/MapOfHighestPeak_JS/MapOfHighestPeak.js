/**
 * @param {number[][]} isWater
 * @return {number[][]}
 */
var highestPeak = function (isWater) {
    var queue = []
    var visited = []
    var dir = [1, 0, -1, 0, 1]
    for (let i = 0; i < isWater.length; i++) {
        visited[i] = []
        for (let j = 0; j < isWater.length; j++) {
            if (isWater[i][j] == 1) {
                visited[i][j] = true
                isWater[i][j] = 0
                queue.push([i, j, 1])
            }
        }        
    }
    while (queue.length != 0) {
        var cur = queue.shift()
        for (let i = 0; i < 4; i++) {
            var newX = cur[0] + dir[i]
            var newY = cur[1] + dir[i + 1]
            if (newX < 0 || newX >= isWater.length || newY < 0 || newY >= isWater[0].length)
                continue
            if (!visited[newX][newY]) {
                visited[newX][newY] = true
                isWater[newX][newY] = cur[2]
                queue.push([newX, newY, cur[2] + 1])
            }
        }
    }
    return isWater
}
