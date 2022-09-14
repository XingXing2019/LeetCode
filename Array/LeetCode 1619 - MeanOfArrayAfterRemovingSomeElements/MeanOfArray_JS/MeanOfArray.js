/**
 * @param {number[]} arr
 * @return {number}
 */
var trimMean = function (arr) {
    arr.sort((a, b) => a - b)
    var count = arr.length * 0.05, sum = 0
    for (let i = count; i < arr.length - count; i++)
        sum += arr[i]
    return sum / (arr.length - 2 * count)
}