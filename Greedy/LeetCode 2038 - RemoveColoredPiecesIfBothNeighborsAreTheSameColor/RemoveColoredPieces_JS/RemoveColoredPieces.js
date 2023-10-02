/**
 * @param {string} colors
 * @return {boolean}
 */
var winnerOfGame = function(colors) {
    colors += '#'
    return count(colors, 'A') > count(colors, 'B')
}

var count = function (colors, target) {
    var count = 0, res = 0;
    for (let i = 0; i < colors.length; i++) {
        if (colors[i] == target)
            count++;
        else {
            res += Math.max(0, count - 2)
            count = 0
        }        
    }
    return res
}