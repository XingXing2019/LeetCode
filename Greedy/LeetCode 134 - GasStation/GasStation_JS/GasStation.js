/**
 * @param {number[]} gas
 * @param {number[]} cost
 * @return {number}
 */
var canCompleteCircuit = function (gas, cost) {
    var net = []
    var total = 0
    for (let i = 0; i < gas.length; i++) {
        net[i] = gas[i] - cost[i]
        total += net[i]
    }
    if (total < 0) return -1
    var res = 0, tank = 0
    for (let i = 0; i < net.length; i++) {
        tank += net[i]
        if (tank < 0) {
            tank = 0
            res = i + 1
        } 
    }
    return res
}
