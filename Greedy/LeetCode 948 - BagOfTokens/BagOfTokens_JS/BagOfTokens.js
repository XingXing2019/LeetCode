/**
 * @param {number[]} tokens
 * @param {number} power
 * @return {number}
 */
var bagOfTokensScore = function(tokens, power) {
    tokens.sort((a, b) => a - b)
    var res = 0, score = 0, li = 0, hi = tokens.length - 1
    while (li <= hi) {
        if (power >= tokens[li]) {
            power -= tokens[li++]
            score++
        } else if (power < tokens[hi] && score > 0) {
            power += tokens[hi--]
            score--
        } else   
            break
        res = Math.max(res, score)
    }
    return res
}