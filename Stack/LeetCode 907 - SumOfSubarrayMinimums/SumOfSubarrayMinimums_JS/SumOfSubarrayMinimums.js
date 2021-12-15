/**
 * @param {number[]} arr
 * @return {number}
 */
var sumSubarrayMins = function (arr) {
    var stack = [];
    var res = 0, mod = 1_000_000_000 + 7;
    for (let i = 0; i < arr.length; i++) {
        while (stack.length != 0 && arr[stack[stack.length - 1]] > arr[i]) {
            var index = stack.pop();
            var left = stack.length == 0 ? index + 1 : index - stack[stack.length - 1];
            var right = i - index;
            res += arr[index] * left * right;
        }   
        stack.push(i);     
    }
    while (stack.length != 0) {
        var index = stack.pop();
        var left = stack.length == 0 ? index + 1 : index - stack[stack.length - 1];
        var right = arr.length - index;
        res += arr[index] * left * right;
    }
    return res % mod;
};