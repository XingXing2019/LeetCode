/**
 * @param {number[][]} boxTypes
 * @param {number} truckSize
 * @return {number}
 */
var maximumUnits = function(boxTypes, truckSize) {
    boxTypes.sort((a, b) => b[1] - a[1])
    var res = 0;
    for (let i = 0; i < boxTypes.length && truckSize > 0; i++) {
        res += Math.min(truckSize, boxTypes[i][0]) * boxTypes[i][1]
        truckSize -= boxTypes[i][0]        
    }
    return res
}