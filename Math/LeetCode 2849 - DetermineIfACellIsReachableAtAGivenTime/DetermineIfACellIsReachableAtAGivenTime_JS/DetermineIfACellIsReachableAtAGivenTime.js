/**
 * @param {number} sx
 * @param {number} sy
 * @param {number} fx
 * @param {number} fy
 * @param {number} t
 * @return {boolean}
 */
var isReachableAtTime = function(sx, sy, fx, fy, t) {
    var dx = Math.abs(sx - fx), dy = Math.abs(sy - fy)
    if (dx == 0 && dy == 0 && t == 1) return false
    return t - Math.min(dx, dy) >= Math.abs(dx - dy)
}