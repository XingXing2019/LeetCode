/**
 * @param {number[]} temperatures
 * @return {number[]}
 */
var dailyTemperatures = function (temperatures) {
    var res = [];
    for (let i = 0; i < temperatures.length; i++)
        res.push(0);
    var stack = [];
    for (let i = 0; i < temperatures.length; i++) {
        while (stack.length != 0 && temperatures[i] > temperatures[stack[stack.length - 1]])
            res[stack[stack.length - 1]] = i - stack.pop();
        stack.push(i);
    }
    return res;
};