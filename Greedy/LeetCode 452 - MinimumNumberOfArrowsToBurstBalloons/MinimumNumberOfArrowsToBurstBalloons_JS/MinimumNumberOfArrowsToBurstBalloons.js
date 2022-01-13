/**
 * @param {number[][]} points
 * @return {number}
 */
var findMinArrowShots = function (points) {
    points.sort((a, b) => a[0] - b[0])
    var res = 1, pos = points[0][1]
    for (const point of points) {        
        if (pos > point[1])
            pos = point[1]
        else if (pos < point[0]) {
            res++
            pos = point[1]
        }
    }
    return res
}
