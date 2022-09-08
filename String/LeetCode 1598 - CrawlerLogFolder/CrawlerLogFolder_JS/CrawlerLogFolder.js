/**
 * @param {string[]} logs
 * @return {number}
 */
var minOperations = function(logs) {
    var level = 0
    for (let i = 0; i < logs.length; i++) {
        if (logs[i] == './')
            continue
        else if (logs[i] == '../')
            level = Math.max(0, level - 1)
        else
            level++
    }
    return level
}