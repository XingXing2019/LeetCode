/**
 * @param {number[][]} intervals
 * @param {number[]} toBeRemoved
 * @return {number[][]}
 */
var removeInterval = function(intervals, toBeRemoved) {
    var res = []
    for (let i = 0; i < intervals.length; i++) {
        var interval = intervals[i]
        var start = toBeRemoved[0], end = toBeRemoved[1]
        if (start < interval[0] && end > interval[1])
            continue
        if (interval[0] < start && end < interval[1])
            res.push([interval[0], start], [end, interval[1]])            
        else if (interval[1] <= start || end <= interval[0])
            res.push(interval)
        else if (interval[0] < start && start < interval[1])
            res.push([interval[0], start])
        else if (interval[0] < end && end < interval[1])
            res.push([end, interval[1]])
    }
    return res
}