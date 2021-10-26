/**
 * @param {string} s
 * @return {number}
 */
 var romanToInt = function(s) {
    let map = {'I': 1, 'V': 5, 'X': 10, 'L': 50, 'C': 100, 'D': 500, 'M': 1000};
    let digits = new Array(s.length);
    for (let i = 0; i < s.length; i++) {
        digits[i] = map[s[i]];
        if (i != 0 && digits[i] > digits[i - 1])
            digits[i - 1] *= -1;
    }
    let res = 0;
    digits.forEach(x => {
        res += x;
    });
    return res;
};