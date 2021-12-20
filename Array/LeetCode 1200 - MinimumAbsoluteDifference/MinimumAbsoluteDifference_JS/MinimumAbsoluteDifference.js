/**
 * @param {number[]} arr
 * @return {number[][]}
 */
var minimumAbsDifference = function (arr) {
    arr.sort((a, b) => {return a - b});
    var min = Number.MAX_VALUE;
    var res = [];
    var set = new Set();
    set.add(arr[0]);
    for (let i = 1; i < arr.length; i++) {
        min = Math.min(min, arr[i] - arr[i - 1]);
        set.add(arr[i]);
    }
    for (let i = 1; i < arr.length; i++) {
        if (set.has(arr[i] - min))
            res.push([arr[i] - min, arr[i]]);        
    }
    return res;
};