/**
 * @param {number} n
 * @param {number[][]} connections
 * @return {number}
 */
var makeConnected = function(n, connections) {
    parent = new Array(n)
    rank = new Array(n).fill(0)
    var extra = 0
    for (let i = 0; i < n; i++) 
        parent[i] = i
    var find = function (x) {
        if (x != parent[x])
            parent[x] = find(parent[x])
        return parent[x]
    }
    var union = function (x, y) {
        var rootX = find(x), rootY = find(y)
        if (rootX == rootY)
            return false
        if (rank[rootX] >= rank[rootY]) {
            parent[rootY] = rootX
            if (rank[rootX] == rank[rootY])
                rank[rootX]++
        } else
            parent[rootX] = rootY
        return true
    }
    for (let i = 0; i < connections.length; i++) {
        if (!union(connections[i][0], connections[i][1]))
            extra++
        else
            n--        
    }
    return extra >= n - 1 ? n - 1 : -1
}

