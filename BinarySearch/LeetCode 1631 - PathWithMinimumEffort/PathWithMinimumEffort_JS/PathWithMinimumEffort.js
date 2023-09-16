/**
 * @param {number[][]} heights
 * @return {number}
 */
var minimumEffortPath = function (heights) {
    var m = heights.length, n = heights[0].length
    var dfs = function(x, y, oldHeight, max, visited) {
        if (x < 0 || x >= m || y < 0 || y >= n || visited[x][y] || Math.abs(oldHeight - heights[x][y]) > max)
            return false
        if (x == m - 1 && y == n - 1)
            return true
        visited[x][y] = true
        return dfs(x + 1, y, heights[x][y], max, visited) ||
               dfs(x - 1, y, heights[x][y], max, visited) ||
               dfs(x, y + 1, heights[x][y], max, visited) ||
               dfs(x, y - 1, heights[x][y], max, visited)
    }
    var li = 0, hi = 1000000
    while (li <= hi) {
        var mid = li + ~~((hi - li) / 2)
        var visited = new Array(m)
        for (let i = 0; i < m; i++) 
            visited[i] = new Array(n).fill(false)
        if (dfs(0, 0, heights[0][0], mid, visited))
            hi = mid - 1;
        else
            li = mid + 1;
    }
    return li
}

