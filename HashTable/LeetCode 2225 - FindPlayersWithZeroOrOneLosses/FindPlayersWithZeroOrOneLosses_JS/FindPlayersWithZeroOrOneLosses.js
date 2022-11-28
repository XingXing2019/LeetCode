/**
 * @param {number[][]} matches
 * @return {number[][]}
 */
var findWinners = function(matches) {
    var map = new Map()
    matches.forEach(x => {
        if (!map.has(x[0]))
            map.set(x[0], 0)
        if (!map.has(x[1]))
            map.set(x[1], 0)
        map.set(x[1], map.get(x[1]) + 1)
    });
    var noLoss = [], lossOne = []
    for (let [key, value] of map) {
        if (value == 0)
            noLoss.push(key)
        else if (value == 1)
            lossOne.push(key)
    }
    noLoss.sort((a, b) => a - b)
    lossOne.sort((a, b) => a - b)
    return [noLoss, lossOne]
}