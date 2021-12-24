/**
 * @param {number[][]} intervals
 * @param {number[]} newInterval
 * @return {number[][]}
 */
var insert = function (intervals, newInterval) {
    var inserted = false;
    var res = [];
    var li = newInterval[0], hi = newInterval[1];
    intervals.forEach(x => {
        if (x[0] <= li && li <= x[1] || x[0] <= hi && hi <= x[1]) {
            li = Math.min(li, x[0]);
            hi = Math.max(hi, x[1]);
        } else if (x[1] < newInterval[0]) {
            res.push(x);
        } else if (x[0] > newInterval[1]) {
            if (!inserted) {
                res.push([li, hi]);
                inserted = true;
            }
            res.push(x);
        }
    });
    if (!inserted) res.push([li, hi]);
    return res;
};