/**
 * @param {number[]} arr
 * @param {number[][]} queries
 * @return {number[]}
 */
var xorQueries = function (arr, queries) {
    for (let i = 1; i < arr.length; i++)
        arr[i] ^= arr[i - 1];
    var res = [];
    queries.forEach(x => {
        var xOr = x[0] == 0 ? arr[x[1]] : arr[x[1]] ^ arr[x[0] - 1];
        res.push(xOr);
    });
    return res;
};