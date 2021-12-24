/**
 * @param {number[][]} intervals
 * @return {number[][]}
 */
var merge = function (intervals) {
    intervals.sort((a, b) => {return a[0] - b[0]});
    var res = []
    var li = intervals[0][0], hi = intervals[0][1];
    for (let i = 0; i < intervals.length; i++) {
        if (li <= intervals[i][0] && intervals[i][0] <= hi) {
            li = Math.min(li, intervals[i][0]);
            hi = Math.max(hi, intervals[i][1]);
        } else {
            res.push([li, hi]);
            li = intervals[i][0];
            hi = intervals[i][1];
        }        
    }
    res.push([li, hi]);
    return res;
};