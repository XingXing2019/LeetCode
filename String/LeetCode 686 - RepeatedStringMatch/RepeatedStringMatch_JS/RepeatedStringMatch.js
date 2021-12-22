/**
 * @param {string} a
 * @param {string} b
 * @return {number}
 */
var repeatedStringMatch = function (a, b) {
    var res = 1;
    var temp = a;
    while (temp.length < b.length) {
        temp += a;
        res++;
    }
    if (temp.match(new RegExp(b)))
        return res;
    else if ((temp + a).match(new RegExp(b)))
        return res + 1;
    return -1;
};