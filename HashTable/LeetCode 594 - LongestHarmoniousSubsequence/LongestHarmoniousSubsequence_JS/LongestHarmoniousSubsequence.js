/**
 * @param {number[]} nums
 * @return {number}
 */
var findLHS = function (nums) {
    var map = {};
    nums.forEach(num => {
        if (!map[num])
            map[num] = 0;
        map[num]++;
    });
    var res = 0;
    for (const num of nums) {
        var smaller = isNaN(map[num - 1]) ? 0 : map[num - 1];
        var larger = isNaN(map[num + 1]) ? 0 : map[num + 1];
        if (!smaller && !larger) continue;
        res = Math.max(res, Math.max(smaller, larger) + map[num]);
    }
    return res;
};