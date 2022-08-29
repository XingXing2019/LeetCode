/**
 * @param {number[][]} maze
 * @param {number[]} start
 * @param {number[]} destination
 * @return {number}
 */
var shortestDistance = function (maze, start, destination) {
    var dir = [[1, 0], [-1, 0], [0, 1], [0, -1]]
    var m = maze.length, n = maze[0].length
    var queue = [], dis = []
    queue.push([start[0], start[1], 0])
    for (let i = 0; i < m; i++) {
        dis.push(new Array(n).fill(Number.MAX_VALUE))
    }
    dis[start[0]][start[1]] = 0
    while (queue.length != 0) {
        var cur = queue.shift()
        for (let i = 0; i < 4; i++) {
            var x = cur[0], y = cur[1], step = 0
            for (let j = 0; j < Math.max(m, n); j++) {
                var newX = x + dir[i][0]
                var newY = y + dir[i][1]
                if (newX < 0 || newX >= m || newY < 0 || newY >= n || maze[newX][newY] == 1)
                    break
                x = newX
                y = newY
                step++
            }
            if (dis[cur[0]][cur[1]] + step < dis[x][y]) {
                dis[x][y] = dis[cur[0]][cur[1]] + step
                queue.push([x, y, cur[2] + step])
            }
        }
    }
    return dis[destination[0]][destination[1]] == Number.MAX_VALUE ? -1 : dis[destination[0]][destination[1]]
}