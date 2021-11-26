/**
 * @param {string} s
 * @return {boolean}
 */
var canPermutePalindrome = function (s) {
    var map = new Map();
    for (let i = 0; i < s.length; i++) {
        if (!map.has(s[i]))
            map.set(s[i], 0);
        map.set(s[i], map.get(s[i]) + 1);
    }
    var count = 0;
    map.forEach((val, key) => {
        if (val % 2 != 0)
            count++;
    });
    return count <= 1;
};