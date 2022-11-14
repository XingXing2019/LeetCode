/**
 * @param {number[][]} stones
 * @return {number}
 */
var removeStones = function(stones) {
    var parents = [], rank = []
    for (let i = 0; i < stones.length; i++) {
        rank.push(0)
        parents.push(i)
    }
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
    var group = stones.length
    for (let i = 0; i < stones.length; i++) {   
        for (let j = i + 1; j < stones.length; j++) {
            var s1 = stones[i], s2 = stones[j]
            if (s1[0] != s2[0] && s1[1] != s2[1]) continue
            if (!union(i, j)) continue
            group--            
        }        
    }
    return stones.length - group
}