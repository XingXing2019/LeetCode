/**
 * @param {number[][]} graph
 * @return {number}
 */
var shortestPathLength = function(graph) {
    var res = Number.MAX_SAFE_INTEGER
    for (let i = 0; i < graph.length; i++) 
        res = Math.min(res, bfs(graph, i))
    return res
}

var bfs = function (graph, start) {
    var n = graph.length
    var visited = new Array(n)
    for (let i = 0; i < n; i++)
        visited[i] = new Array(1 << n).fill(false)
    var queue = [[start, 1 << start, 0]]
    visited[start][1 << start] = true
    while (queue.length != 0) {
        var cur = queue.shift()
        if (cur[1] == (1 << n) - 1)
            return cur[2]
        for (let i = 0; i < graph[cur[0]].length; i++) {
            var next = graph[cur[0]][i]
            if (visited[next][cur[1] | (1 << next)])
                continue
            visited[next][cur[1] | (1 << next)] = true
            queue.push([next, cur[1] | (1 << next), cur[2] + 1])
        }
    }
    return -1
}