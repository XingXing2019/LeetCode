/**
 * @param {number} n
 * @param {number[][]} roads
 * @return {number}
 */
var minScore = function (n, roads) {    
    var res = 0
    var graph = new Array(n + 1)    
    for (let i = 0; i < n + 1; i++)
        graph[i] = []
    roads.forEach(x => {
        graph[x[0]].push([x[1], x[2]])
        graph[x[1]].push([x[0], x[2]])
        res = Math.max(res, x[2])
    })
    var visited = new Array(n + 1).fill(false)
    var queue = [1]
    visited[1] = true
    while (queue.length != 0) {
        var cur = queue.shift()
        for (let i = 0; i < graph[cur].length; i++) {
            var nextCity = graph[cur][i][0]
            var nextDis = graph[cur][i][1]
            res = Math.min(res, nextDis)
            if (visited[nextCity]) continue
            visited[nextCity] = true
            queue.push(nextCity)
        }
    }
    return res
};