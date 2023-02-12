/**
 * @param {number[][]} roads
 * @param {number} seats
 * @return {number}
 */
var minimumFuelCost = function(roads, seats) {
    var graph = new Array(roads.length + 1)
    for (let i = 0; i < graph.length; i++)
        graph[i] = []
    roads.forEach(x => {
        graph[x[0]].push(x[1])
        graph[x[1]].push(x[0])
    })
    var res = 0
    var dfs = function (cur, visited) {
        var count = 1
        for (let i = 0; i < graph[cur].length; i++) {
            var next = graph[cur][i]
            if (visited.has(next)) continue
            visited.add(next)
            count += dfs(next, visited)
        }
        if (cur == 0) return count
        res += Math.ceil(count / seats)
        return count
    }
    var visited = new Set()
    visited.add(0)
    dfs(0, visited)
    return res
}