/**
 * @param {string[][]} equations
 * @param {number[]} values
 * @param {string[][]} queries
 * @return {number[]}
 */
var calcEquation = function(equations, values, queries) {
    var graph = {}
    for (let i = 0; i < equations.length; i++) {
        var a = equations[i][0], b = equations[i][1]
        if (!graph[a])
            graph[a] = []
        graph[a].push([b, values[i]])
        if (!graph[b])
            graph[b] = []
        graph[b].push([a, 1 / values[i]])
    }
    var res = new Array(queries.length).fill(-1)
    for (let i = 0; i < queries.length; i++)
        dfs(graph, queries[i][0], queries[i][1], 1, new Set(), i, res)
    return res
}   

var dfs = function (graph, cur, target, mul, visited, index, res) {    
    if (!graph[cur])
        return
    if (cur == target) {
        res[index] = mul
        return
    }
    for (const next of graph[cur]) {
        if (visited.has(next[0])) continue
        visited.add(next[0])
        dfs(graph, next[0], target, mul * next[1], visited, index, res)
        visited.delete(next[0])
    }
}