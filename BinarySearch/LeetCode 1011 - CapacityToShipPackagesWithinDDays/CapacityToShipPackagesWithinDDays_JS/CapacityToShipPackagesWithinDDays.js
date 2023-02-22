/**
 * @param {number[]} weights
 * @param {number} days
 * @return {number}
 */
var shipWithinDays = function (weights, days) {
    var canLoad = function (weights, capacity, days) {
        load = 0
        for (let i = 0; i < weights.length; i++) {
            if (load + weights[i] > capacity) {
                days--
                load = weights[i]
            } else 
                load += weights[i]
        }
        return days - 1 >= 0
    }
    var li = 0, hi = 0
    for (let i = 0; i < weights.length; i++) {
        hi += weights[i]
        li = Math.max(li, weights[i])
    }   
    while (li < hi) {
        var mid = li + ~~((hi - li) / 2)
        if (canLoad(weights, mid, days))
            hi = mid
        else
            li = mid + 1
    }
    return li
}