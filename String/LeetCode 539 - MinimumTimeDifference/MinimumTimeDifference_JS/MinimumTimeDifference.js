/**
 * @param {string[]} timePoints
 * @return {number}
 */
var findMinDifference = function (timePoints) {
    var times = []
    timePoints.forEach(x => {
        var parts = x.split(':')
        var hour = parseInt(parts[0]), min = parseInt(parts[1])
        var mins = hour * 60 + min
        times.push(mins)
        times.push(mins + 24 * 60)
    })
    times.sort((a, b) => a - b)
    var res = Number.MAX_VALUE
    for (let i = 1; i < times.length; i++) 
        res = Math.min(res, times[i] - times[i - 1])
    return res
}
