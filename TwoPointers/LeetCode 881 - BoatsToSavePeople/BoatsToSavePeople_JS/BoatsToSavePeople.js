/**
 * @param {number[]} people
 * @param {number} limit
 * @return {number}
 */
var numRescueBoats = function (people, limit) {
    people.sort((a, b) => { return a - b })
    var li = 0, hi = people.length - 1, res = 0
    while (li < hi) {
        if (people[li] + people[hi] <= limit)
            li++
        hi--;
        res++;
    }
    return li == hi ? res + 1 : res
}
