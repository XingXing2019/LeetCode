/**
 * @param {number} n
 * @param {number[][]} edges
 * @return {number}
 */
var countComponents = function(n, edges) {
    var parents = new Array(n)
    var rank = new Array(n)
    for (let i = 0; i < n; i++)
        parents[i] = i
    var find = function (x) {
        if (parents[x] != x)
            parents[x] = find(parents[x])
        return parents[x]
    }
    var union = function (x, y) {
        var rootX = find(x), rootY = find(y)
        if (rootX == rootY)
            return false
        if (rank[rootX] >= rank[rootY]) {
            parents[rootY] = rootX
            if (rank[rootX] == rank[rootY])
                rank[rootX]++
        } else
            parents[rootX] = rootY
        return true
    }
    for (let i = 0; i < edges.length; i++) {
        if (union(edges[i][0], edges[i][1]))
            n--        
    }
    return n
};