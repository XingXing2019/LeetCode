/**
 * @param {number[]} dist
 * @param {number[]} speed
 * @return {number}
 */
var eliminateMaximum = function(dist, speed) {
    var times = []
    for (let i = 0; i < dist.length; i++)
        times.push(dist[i] / speed[i])
    times.sort((a, b) => a - b)
    var timer = 0, res = 0
    for (let i = 0; i < times.length; i++) {
        if (times[i] - timer <= 0)
            return res
        res++
        timer++
    }
    return res
}