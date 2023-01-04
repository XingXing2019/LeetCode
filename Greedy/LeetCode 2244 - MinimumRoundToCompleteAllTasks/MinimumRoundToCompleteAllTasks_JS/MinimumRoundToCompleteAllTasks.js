/**
 * @param {number[]} tasks
 * @return {number}
 */
var minimumRounds = function(tasks) {
    var map = {}
    var res = 0
    for (let i = 0; i < tasks.length; i++) {
        if (!map[tasks[i]])
            map[tasks[i]] = 0
        map[tasks[i]] = map[tasks[i]] + 1        
    }
    for (const key in map) {
        var val = map[key]
        if (val == 1) return -1
        if (val % 3 == 0) res += val / 3
        else res += val % 3 == 1 ? ~~((val - 4) / 3) + 2 : ~~(val / 3) + 1
    }
    return res
}