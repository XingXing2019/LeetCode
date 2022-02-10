/**
 * @param {number} n
 * @return {string[]}
 */
var simplifiedFractions = function (n) {
    var res = []
    var set = new Set()
    for (let i = 1; i <= n; i++) {
        for (let j = 1; j < i; j++) {
            if (!set.has(j / i)) {
                set.add(j / i)
                res.push(`${j}/${i}`)
            }
        }    
    }
    return res
}
