/**
 * @param {number[]} height
 * @return {number}
 */
var maxArea = function (height) {
    var li = 0, hi = height.length - 1, res = 0;
    while (li < hi) {
        res = Math.max(res, Math.min(height[li], height[hi]) * (hi - li))
        if (height[li] < height[hi])
            li++;
        else
            hi--
    }
    return res
}
