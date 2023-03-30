/**
 * @param {string} s1
 * @param {string} s2
 * @return {boolean}
 */
var isScramble = function(s1, s2) {
    return dfs(s1, s2, new Set())
}

var dfs = function (s1, s2, visited) {
    if (s1 == s2)
        return true
    if (s1.length != s2.length) {
        visited.add(`${s1}:${s2}`)
        return false
    }    
    if (visited.has(`${s1}:${s2}`))
        return false
    for (let i = 1; i < s1.length; i++) {
        var l1 = s1.substring(0, i)
        var r1 = s1.substring(i)
        var l2 = s2.substring(0, i)
        var r2 = s2.substring(i)
        if (dfs(l1, l2, visited) && dfs(r1, r2, visited) || dfs(l1, r2, visited) && dfs(l2, r1, visited))
            return true
        var l2 = s2.substring(0, s2.length - i)
        var r2 = s2.substring(s2.length - i)
        if (dfs(l1, l2, visited) && dfs(r1, r2, visited) || dfs(l1, r2, visited) && dfs(l2, r1, visited))
            return true
    }    
    visited.add(`${s1}:${s2}`)
    return false
}