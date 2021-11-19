/**
 * @param {number} x
 * @param {number} y
 * @return {number}
 */
var hammingDistance = function (x, y) {
    var res = 0;
    while (x != 0 || y != 0) {
        res += (x & 1) ^ (y & 1);
        x >>= 1;
        y >>= 1;
    }
    return res;
};