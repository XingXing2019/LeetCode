/**
 * @param {number[][]} mat
 * @return {number}
 */
var diagonalSum = function(mat) {
    var m = mat.length, n = mat[0].length, res = 0
    for (let i = 0; i < m; i++) 
        res += mat[i][i] + mat[i][n - i - 1]
    return m % 2 == 0 ? res : res - mat[~~(m / 2)][~~(m / 2)]
};