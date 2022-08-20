/**
 * @param {number} target
 * @param {number} startFuel
 * @param {number[][]} stations
 * @return {number}
 */
var minRefuelStops = function (target, startFuel, stations) {
    var heap = []
    var res = 0, index = 0;
    while (startFuel < target) {
        while (index < stations.length && startFuel >= stations[index][0])
            heap.push(stations[index++][1])
        if (heap.length == 0)
            return -1
        heap.sort((a, b) => a - b);
        startFuel += heap.pop();
        res++
    }
    return res
}
