/**
 * @param {number[][]} rectangles
 * @return {number}
 */
var countGoodRectangles = function (rectangles) {
    var map = {}
    var max = 0
    rectangles.forEach(x => {
        var len = Math.min(x[0], x[1])
        if (!map[len]) map[len] = 0
        map[len]++
        max = Math.max(max, len)
    });
    return map[max]
}
