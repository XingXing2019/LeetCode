/**
 * @param {number} x
 * @return {boolean}
 */
var isPalindrome = function (x) {
    if (x < 0) return false;
    var copy = x;
    var num = 0;
    while (copy != 0) {
        num = num * 10 + copy % 10;
        copy = ~~(copy / 10);
    }
    return num == x;
}
