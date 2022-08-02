/**
 * @param {number[][]} matrix
 * @param {number} k
 * @return {number}
 */
var kthSmallest = function(matrix, k) {
    var binarySearch = function (row, target) {
        var li = 0, hi = row.length - 1;
        while (li <= hi) {
            var mid = li + ~~((hi - li) / 2);
            if (row[mid] == target)
                return mid;
            if (row[mid] < target)
                li = mid + 1;
            else
                hi = mid - 1;
        }
        return li;
    }
    var n = matrix.length;
    var li = matrix[0][0], hi = matrix[n - 1][n - 1];
    while (li <= hi) {
        var mid = li + ~~((hi - li) / 2);
        var count = 0;
        matrix.forEach(row => {
            count += binarySearch(row, mid);
        });
        if (count < k - 1)
            li = mid + 1;
        else
            hi = mid - 1;
    }
    return hi;
};