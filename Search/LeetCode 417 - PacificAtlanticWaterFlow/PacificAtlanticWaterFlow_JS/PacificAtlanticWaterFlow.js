/**
 * @param {number[][]} heights
 * @return {number[][]}
 */
var pacificAtlantic = function (heights) {
    var m = heights.length, n = heights[0].length
    var reachP = [], reachA = []
    for (let i = 0; i < m; i++) {
        reachP.push(new Array(n).fill(false))
        reachA.push(new Array(n).fill(false))
    }
    for (let x = 0; x < m; x++) {
        dfs(heights, x, 0, heights[x][0], reachP)
        dfs(heights, x, n - 1, heights[x][n - 1], reachA)
    }
    for (let y = 0; y < n; y++) {
        dfs(heights, 0, y, heights[0][y], reachP)
        dfs(heights, m - 1, y, heights[m - 1][y], reachA)
    }
    var res = []
    for (let x = 0; x < m; x++) {
        for (let y = 0; y < n; y++) {
            if (reachP[x][y] && reachA[x][y]) 
                res.push([x, y])
        }
    }
    return res
}

var dfs = function (heights, x, y, last, visited) {
    var m = heights.length, n = heights[0].length
    if (x < 0 || x >= m || y < 0 || y >= n || visited[x][y] || last > heights[x][y])
        return
    visited[x][y] = true
    dfs(heights, x + 1, y, heights[x][y], visited)
    dfs(heights, x - 1, y, heights[x][y], visited)
    dfs(heights, x, y + 1, heights[x][y], visited)
    dfs(heights, x, y - 1, heights[x][y], visited)
}
