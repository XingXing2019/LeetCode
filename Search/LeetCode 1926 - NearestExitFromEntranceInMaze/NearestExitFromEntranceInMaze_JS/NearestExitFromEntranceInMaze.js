/**
 * @param {character[][]} maze
 * @param {number[]} entrance
 * @return {number}
 */
var nearestExit = function (maze, entrance) {
    var m = maze.length, n = maze[0].length
    var visited = new Array(m)
    for (let i = 0; i < m; i++)
        visited[i] = new Array(n).fill(false)
    var queue = [[entrance[0], entrance[1]]]
    visited[entrance[0]][entrance[1]] = true
    var step = 0
    var dir = [1, 0, -1, 0, 1]
    while (queue.length != 0) {
        var count = queue.length
        for (let i = 0; i < count; i++) {
            var cur = queue.shift()
            if (step != 0 && (cur[0] == 0 || cur[0] == m - 1 || cur[1] == 0 || cur[1] == n - 1))
                return step
            for (let j = 0; j < 4; j++) {
                var x = cur[0] + dir[j], y = cur[1] + dir[j + 1]
                if (x < 0 || x >= m || y < 0 || y >= n || visited[x][y] || maze[x][y] == '+')
                    continue
                visited[x][y] = true
                queue.push([x, y])
            }
        }
        step++
    }
    return -1
}