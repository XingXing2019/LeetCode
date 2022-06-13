/**
 * @param {number[][]} triangle
 * @return {number}
 */
var minimumTotal = function (triangle) {
    if (triangle.length == 1)
        return triangle[0][0];
    var res = Number.MAX_VALUE;
    for (let i = 1; i < triangle.length; i++) {
        for (let j = 0; j < triangle[i].length; j++) {
            if (j == 0)
                triangle[i][j] += triangle[i - 1][j];
            else if (j == triangle[i].length - 1)
                triangle[i][j] += triangle[i - 1][j - 1];
            else
                triangle[i][j] += Math.min(triangle[i - 1][j], triangle[i - 1][j - 1]);
            if (i == triangle.length - 1)
                res = Math.min(res, triangle[i][j]);
        }        
    }
    return res;
}
