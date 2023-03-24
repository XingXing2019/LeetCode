/**
 * @param {number} n
 * @param {number[][]} connections
 * @return {number}
 */
var minReorder = function(n, connections) {
    var graph = new Array(n)
    var visited = new Array(n).fill(false)
    var directions = new Set()
    var res = 0
    for (let i = 0; i < n; i++)
        graph[i] = []
    for (let i = 0; i < connections.length; i++) {
        graph[connections[i][0]].push(connections[i][1])
        graph[connections[i][1]].push(connections[i][0])
        directions.add(`${connections[i][0]}-${connections[i][1]}`)
    }
    var queue = [0]
    visited[0] = true
    while (queue.length != 0) {
        var cur = queue.shift()
        for (let i = 0; i < graph[cur].length; i++) {
            var next = graph[cur][i]
            if (visited[next]) continue
            if (!directions.has(`${next}-${cur}`))
                res++            
            visited[next] = true   
            queue.push(next)
        }
    }
    return res
}