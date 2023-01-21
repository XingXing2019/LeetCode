/**
 * @param {string} s
 * @return {string[]}
 */
var restoreIpAddresses = function (s) {
    var res = []
    dfs(s, '', 0, res)
    return res
}

var dfs = function (s, cur, count, res) {
    if (count >= 4) {
        if (count == 4 && s === '')
            res.push(cur)
        return
    }
    for (let i = 1; i <= Math.min(3, s.length); i++) {
        var next = s.substring(0, i)
        if (next[0] == '0' && i != 1 || +next > 255)
            continue
        dfs(s.substring(i), cur === '' ? next :`${cur}.${next}`, count + 1, res)        
    }
}