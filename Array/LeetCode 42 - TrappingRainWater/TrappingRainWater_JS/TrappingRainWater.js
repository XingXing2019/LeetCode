/**
 * @param {number[]} height
 * @return {number}
 */
var trap = function (height) {
    var leftMax = new Array(height.length), rightMax = new Array(height.length);
    var left = 0, right = 0, res = 0;
    for (let i = 0; i < height.length; i++) {
        leftMax[i] = left;
        left = Math.max(left, height[i]);
        rightMax[height.length - i - 1] = right;
        right = Math.max(right, height[height.length - i - 1]);        
    }
    for (let i = 0; i < height.length; i++)
        res += Math.max(0, Math.min(leftMax[i], rightMax[i]) - height[i]);
    return res;
};