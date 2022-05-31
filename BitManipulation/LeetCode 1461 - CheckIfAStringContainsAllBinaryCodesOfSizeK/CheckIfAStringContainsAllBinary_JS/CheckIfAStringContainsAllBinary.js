/**
 * @param {string} s
 * @param {number} k
 * @return {boolean}
 */
var hasAllCodes = function (s, k) {
    if (k > s.length) return false;
    var set = new Set();
    var num = 0, pow = 0.5;
    for (let i = 0; i < k; i++) {
        num = num * 2 + Number.parseInt(s[i]);
        pow *= 2;
    }
    for (let i = 0; i <= s.length - k; i++) {
        set.add(num);
        num = (num - Number.parseInt(s[i]) * pow) * 2 + Number.parseInt(s[i + k]);
    }
    return set.size == pow * 2;
}
