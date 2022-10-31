/**
 * @param {number[][]} matrix
 * @return {boolean}
 */
var isToeplitzMatrix = function(matrix) {
    for (let i = 0; i < matrix.length; i++) {
        for (let j = 0; i + j < matrix.length && j < matrix[0].length; j++) {
            if (matrix[i + j][j] == matrix[i][0]) continue
            return false;            
        }        
    }
    for (let j = 1; j < matrix[0].length; j++) {
        for (let i = 0; i < matrix.length && i + j < matrix[0].length; i++) {
            if (matrix[i][i + j] == matrix[0][j]) continue
            return false            
        }        
    }
    return true
}

