/**
 * @param {number[]} piles
 * @param {number} h
 * @return {number}
 */
var minEatingSpeed = function (piles, h) {
    var li = 1, hi = Math.max(...piles)
    while (li <= hi) {
        var mid = li + ~~((hi - li) / 2)
        var time = 0
        piles.forEach(x => {
            time += Math.ceil(x / mid)
        });
        if (time <= h)
            hi = mid - 1
        else
            li = mid + 1
    }
    return li
}
