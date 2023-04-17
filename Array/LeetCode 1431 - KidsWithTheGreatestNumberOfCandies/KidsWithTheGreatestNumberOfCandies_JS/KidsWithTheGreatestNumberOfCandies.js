/**
 * @param {number[]} candies
 * @param {number} extraCandies
 * @return {boolean[]}
 */
var kidsWithCandies = function(candies, extraCandies) {
    var max = Math.max(...candies)   
    var res = []
    for (let i = 0; i < candies.length; i++)
        res.push(candies[i] + extraCandies >= max)
    return res
}