/**
 * @param {number[]} security
 * @param {number} time
 * @return {number[]}
 */
var goodDaysToRobBank = function (security, time) {
    var asc = [], desc = [], res = []
    if (time == 0) {
        for (let i = 0; i < security.length; i++)
            res[i] = i
        return res
    }
    var countAsc = 0, countDesc = 0
    for (let i = 0; i < security.length; i++) {
        asc[i] = false
        desc[i] = false
    }
    for (let i = 0; i < security.length; i++) {
        if (security[i] <= security[i - 1])
            countDesc++
        else
            countDesc = 0
        if (countDesc >= time)
            desc[i] = true
    }
    for (let i = security.length - 2; i >= 0; i--) {
        if (security[i] <= security[i + 1])
            countAsc++
        else
            countAsc = 0
        if (countAsc >= time)
            asc[i] = true
    }
    for (let i = 0; i < security.length; i++) {
        if (asc[i] && desc[i])
            res.push(i)
    }
    return res
}
