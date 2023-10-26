/**
 * @param {number[]} arr
 * @return {number}
 */
var numFactoredBinaryTrees = function(arr) {
    var dp = new Map()
    var res = 0, mod = 1_000_000_000 + 7
    arr.sort((a, b) => a - b)
    for (let i = 0; i < arr.length; i++)
        dp.set(arr[i], 1)
    for (let i = 0; i < arr.length; i++) {
        var temp = 0
        for (let j = 0; j < i; j++) {
            if (!dp.has(arr[i] / arr[j])) continue
            temp += dp.get(arr[j]) * dp.get(arr[i] / arr[j])
        }
        dp.set(arr[i], dp.get(arr[i]) + temp)
        res += dp.get(arr[i])
    }
    return res % mod
};