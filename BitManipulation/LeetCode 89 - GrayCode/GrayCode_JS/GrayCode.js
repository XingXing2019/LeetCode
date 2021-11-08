/**
 * @param {number} n
 * @return {number[]}
 */
var grayCode = function (n) {
    var res = [];
    for (let i = 0; i < Math.pow(2, n).length; i++)
        res.push((i >> 1) ^ i);
    return res;
};