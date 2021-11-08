/**
 * @param {number} n
 * @return {number}
 */
var numTrees = function (n) {
    var dfs = function (n, map) {
        if (map.has(n)) return map.get(n);
        if (n == 0 || n == 1) return 1;
        var count = 0;
        for (let i = 0; i < n; i++)
            count += dfs(i, map) * dfs(n - i - 1, map);
        map.set(n, count);
        return count;
    };
    var map = new Map();
    return dfs(n, map);
};