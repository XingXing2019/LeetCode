/**
 * @param {number} n
 * @param {number[]} leftChild
 * @param {number[]} rightChild
 * @return {boolean}
 */
var validateBinaryTreeNodes = function (n, leftChild, rightChild) {
    var find = function (x) {
        if (x != parents[x])
            parents[x] = find(parents[x])
        return parents[x]
    }
    var union = function (x, y) {
        var rootX = find(x), rootY = find(y)
        if (rootX == rootY)
            return false
        if (rank[rootX] < rank[rootY])
            parents[rootX] = parents[rootY]
        else {
            parents[rootY] = parents[rootX]
            if (rank[rootX] == rank[rootY])
                rank[rootX]++
        }
        return true
    }
    var nodes = new Set()
    var parents = new Array(n)
    for (let i = 0; i < n; i++) {
        parents[i] = i
        nodes.add(i)
    }        
    var rank = new Array(n)
    for (let i = 0; i < n; i++) {
        if (leftChild[i] != -1 && (!nodes.delete(leftChild[i]) || !union(i, leftChild[i])))   
            return false
        if (rightChild[i] != -1 && (!nodes.delete(rightChild[i]) || !union(i, rightChild[i])))
            return false
    }
    var root = find(parents[0])
    for (let i = 0; i < n; i++) {
        if (find(parents[i]) == root) continue
        return false
    }
    return true
}

