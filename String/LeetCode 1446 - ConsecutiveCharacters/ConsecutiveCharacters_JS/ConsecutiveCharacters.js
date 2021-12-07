/**
 * @param {string} s
 * @return {number}
 */
var maxPower = function (s) {
    var c = s[0];
    var count = 0;
    var res = 0;
    for (let i = 0; i < s.length; i++) {
        if (s[i] === c)
            count++;
        else {
            res = Math.max(res, count);
            c = s[i];
            count = 1;
        }
    }
    return Math.max(res, count);
};