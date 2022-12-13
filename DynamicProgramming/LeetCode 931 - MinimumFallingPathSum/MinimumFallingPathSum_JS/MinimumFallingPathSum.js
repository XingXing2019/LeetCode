/**
 * @param {number[][]} matrix
 * @return {number}
 */
var minFallingPathSum = function (matrix) {
    for (let i = 1; i < matrix.length; i++) {
        for (let j = 0; j < matrix[0].length; j++) {
            var min = matrix[i - 1][j]
            if (j != 0) min =
                Math.min(min, matrix[i - 1][j - 1])
            if (j != matrix[0].length - 1)
                min = Math.min(min, matrix[i - 1][j + 1])
            matrix[i][j] += min
        }        
    }
    var res = Number.MAX_VALUE
    for (let j = 0; j < matrix[0].length; j++)
        res = Math.min(res, matrix[matrix.length - 1][j])
    return res
}