/**
 * @param {number[]} capacity
 * @param {number[]} rocks
 * @param {number} additionalRocks
 * @return {number}
 */
var maximumBags = function(capacity, rocks, additionalRocks) {
    var bags = []
    for (let i = 0; i < capacity.length; i++)
        bags.push(capacity[i] - rocks[i])
    var res = 0;
    bags.sort((a, b) => a - b)
    for (let i = 0; i < bags.length && additionalRocks > 0; i++) {
        if (additionalRocks < bags[i]) return res
        additionalRocks -= bags[i]
        res++
    }
    return res
}