/**
 * @param {number[][]} intervals
 * @param {number[]} newInterval
 * @return {number[][]}
 */
var insert = function(intervals, newInterval) {
    var li = newInterval[0], hi = newInterval[1], inserted = false
    var res = []
    for (let i = 0; i < intervals.length; i++) {
        if (!inserted && hi < intervals[i][0]) {
            inserted = true
            res.push([li, hi], intervals[i])
        } else if (intervals[i][0] <= li && li <= intervals[i][1] || intervals[i][0] <= hi && hi <= intervals[i][1]) {
            li = Math.min(li, intervals[i][0])
            hi = Math.max(hi, intervals[i][1])
        } else if (intervals[i][1] < li || intervals[i][0] > hi)
            res.push(intervals[i])
    }
    if (!inserted)
        res.push([li, hi])
    return res
};