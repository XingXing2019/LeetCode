/**
 * @param {number[][]} matrix
 * @param {number} target
 * @return {boolean}
 */
var searchMatrix = function (matrix, target) {
    var li = 0, hi = matrix.length - 1;
    while (li <= hi) {
        var mid = li + ~~((hi - li) / 2)
        if (matrix[mid][0] == target) return true
        if (matrix[mid][0] < target) li = mid + 1;
        else hi = mid - 1;
    }
    if (hi < 0) return false;
    var row = matrix[hi];
    li = 0;
    hi = row.length - 1;
    while (li <= hi) {
        var mid = li + ~~((hi - li) / 2)
        if (row[mid] == target) return true
        if (row[mid] < target) li = mid + 1
        else hi = mid - 1
    }
    return false
}
