/**
 * @param {string} start
 * @param {string} end
 * @param {string[]} bank
 * @return {number}
 */
var minMutation = function(start, end, bank) {
    var valid = new Set()
    for (let i = 0; i < bank.length; i++)
        valid.add(bank[i])
    var queue = [start]
    var visited = new Set()
    visited.add(start)
    var step = 0
    var atp = ['A', 'C', 'G', 'T']
    while (queue.length != 0) {
        var count = queue.length
        for (let i = 0; i < count; i++) {
            var cur = queue.shift()
            if (cur == end) return step
            for (let j = 0; j < cur.length; j++) {
                for (let k = 0; k < atp.length; k++) {
                    if (atp[k] == cur[j]) continue
                    var next = `${cur.substring(0, j)}${atp[k]}${cur.substring(j + 1)}`
                    if (visited.has(next) || !valid.has(next)) continue
                    visited.add(next)
                    queue.push(next)
                }                
            }
        }
        step++
    }
    return -1
}   