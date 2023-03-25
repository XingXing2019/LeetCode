/**
 * @param {number} n
 * @param {number[][]} edges
 * @return {number}
 */
var countPairs = function(n, edges) {
    var parent = new Array(n)
    var rank = new Array(n).fill(0)
    for (let i = 0; i < n; i++)
        parent[i] = i
    var find = function (x) {
        if (x != parent[x])
            parent[x] = find(parent[x])
        return parent[x]
    }
    var union = function (x, y) {
        var rootX = find(x), rootY = find(y)
        if (rootX == rootY) return
        if (rank[x] < rank[rootY])
            parent[rootX] = rootY
        else {
            parent[rootY] = rootX
            if (rank[rootX] == rank[rootY])
                rank[rootX]++
        }            
    }
    for (let i = 0; i < edges.length; i++)
        union(edges[i][0], edges[i][1])
    var map = {}
    for (let i = 0; i < parent.length; i++) {
        var root = find(parent[i])
        if (!map[root])
            map[root] = 0
        map[root]++        
    }
    var res = 0
    for (const root in map)
        res += map[root] * (n - map[root])
    return res / 2
}