/**
 * @param {number} n
 * @return {number}
 */
var lastRemaining = function (n) {
    var res = 1, time = 0, gap = 1;
    while (n != 1) {
        if (time % 2 == 0 || n % 2 != 0)
            res += gap;
        n = ~~(n / 2);
        gap *= 2;
        time++;
    }
    return res;
};