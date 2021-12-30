/**
 * @param {number} k
 * @return {number}
 */
var smallestRepunitDivByK = function (k) {
    var num = 0;
    for (let i = 0; i < k; i++) {
        num = (num * 10 + 1) % k;
        if (num === 0)
            return i + 1;
    }
    return -1;
};