/**
 * @param {string} dominoes
 * @return {string}
 */
var pushDominoes = function (dominoes) {
    var left = [], leftIndex = -1
    var right = [], rightIndex = dominoes.length
    var res = []
    for (let i = 0; i < dominoes.length; i++) {
        left[i] = leftIndex
        if (dominoes[i] != '.') leftIndex = i
        right[dominoes.length - i - 1] = rightIndex
        if (dominoes[dominoes.length - i - 1] != '.') rightIndex = dominoes.length - i - 1
        res[i] = dominoes[i]
    }
    for (let i = 0; i < dominoes.length; i++) {
        if (dominoes[i] != 'L') continue
        if (left[i] == -1 || dominoes[left[i]] == 'L') {
            for (let j = left[i] + 1; j < i; j++) res[j] = 'L'
        } else {
            var li = left[i], hi = i
            while (li < hi) {
                res[li++] = 'R'
                res[hi--] = 'L'
            }
        }
    }
    for (let i = dominoes.length - 1; i >= 0; i--) {
        if (dominoes[i] != 'R') continue
        if (right[i] == dominoes.length || dominoes[right[i]] == 'R') {
            for (let j = i; j < right[i]; j++) res[j] = 'R'
        } else {
            var li = i, hi = right[i]
            while (li < hi) {
                res[li++] = 'R'
                res[hi--] = 'L'
            }
        }         
    }
    return res.join('')
}