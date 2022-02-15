/**
 * @param {number[][]} matrix
 * @return {number[]}
 */
var luckyNumbers = function (matrix) {
    var m = matrix.length, n = matrix[0].length
    var res = []
    var row = new Set()
    for (let i = 0; i < m; i++) {
        var min = matrix[i][0]
        for (let j = 0; j < n; j++)
            min = Math.min(min, matrix[i][j])
        row.add(min)
    }
    for (let j = 0; j < n; j++) {
        var max = matrix[0][j]
        for (let i = 0; i < m; i++)
            max = Math.max(max, matrix[i][j])
        if (row.has(max)) res.push(max)
    }
    return res
}
