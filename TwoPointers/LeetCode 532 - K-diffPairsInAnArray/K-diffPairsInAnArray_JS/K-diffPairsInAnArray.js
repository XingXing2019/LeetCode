/**
 * @param {number[]} nums
 * @param {number} k
 * @return {number}
 */
var findPairs = function (nums, k) {
    var set = new Set(), res = new Set()
    nums.forEach(num => {
        if (set.has(num - k))
            res.add(`${num - k}:${num}`)
        if (set.has(num + k))
            res.add(`${num}:${num + k}`)
        set.add(num)
    });
    return res.size
}
