/**
 * @param {string} s
 * @return {number}
 */
var minFlipsMonoIncr = function(s) {
    var leftOne = new Array(s.length)
    var rightZero = new Array(s.length)
    var zero = 0, one = 0, res = s.length
    for (let i = 0; i < s.length; i++) {
        leftOne[i] = one
        rightZero[s.length - i - 1] = zero
        if (s[i] == '1')
            one++;
        if (s[s.length - i - 1] == '0')
            zero++        
    }
    for (let i = 0; i < s.length; i++)
        res = Math.min(res, leftOne[i] + rightZero[i])
    return res
};