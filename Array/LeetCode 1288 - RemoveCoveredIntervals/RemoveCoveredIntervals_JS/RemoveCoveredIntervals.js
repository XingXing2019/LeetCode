/**
 * @param {number[][]} intervals
 * @return {number}
 */
var removeCoveredIntervals = function (intervals) {
    intervals.sort((a, b) => { return a[0] == b[0] ? b[1] - a[1] : a[0] - b[0] })
    var li = intervals[0][0], hi = intervals[0][1], res = intervals.length
    for (let i = 1; i < intervals.length; i++) {
        if (li <= intervals[i][0] && intervals[i][1] <= hi)
            res--
        hi = Math.max(hi, intervals[i][1])
    }
    return res
}
