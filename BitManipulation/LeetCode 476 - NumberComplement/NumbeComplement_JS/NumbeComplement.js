/**
 * @param {number} num
 * @return {number}
 */
var findComplement = function (num) {
    var index = 0, res = 0;
    while (num != 0) {
        res |= ((num & 1) == 0 ? 1 : 0) << index;
        index++;
        num >>= 1;
    }
    return res;
};