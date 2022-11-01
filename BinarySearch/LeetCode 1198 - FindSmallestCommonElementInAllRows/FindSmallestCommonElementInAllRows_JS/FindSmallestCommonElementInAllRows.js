/**
 * @param {number[][]} mat
 * @return {number}
 */
var smallestCommonElement = function (mat) {
    var m = mat.length, n = mat[0].length
    for (let j = 0; j < n; j++) {
        var isValid = true
        for (let i = 1; i < m; i++) {
            if (!hasNum(mat[i], mat[0][j])) {
                isValid = false
                break
            }
        }
        if (!isValid) continue
        return mat[0][j]
    }
    return - 1
}

var hasNum = function (row, num) {
    var li = 0, hi = row.length - 1
    while (li <= hi) {
        var mid = li + ~~((hi - li) / 2)
        if (row[mid] == num)
            return true;
        if (row[mid] < num)
            li = mid + 1
        else
            hi = mid - 1
    }
    return false
}