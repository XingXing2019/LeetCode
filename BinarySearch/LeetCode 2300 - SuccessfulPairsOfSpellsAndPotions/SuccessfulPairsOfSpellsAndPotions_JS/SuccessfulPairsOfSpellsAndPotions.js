/**
 * @param {number[]} spells
 * @param {number[]} potions
 * @param {number} success
 * @return {number[]}
 */
var successfulPairs = function(spells, potions, success) {
    var binarySearch = function (nums, target) {
        var li = 0, hi = nums.length
        while (li <= hi) {
            var mid = li + ~~((hi - li) / 2)
            if (nums[mid] >= target)
                hi = mid - 1
            else 
                li = mid + 1
        }
        return li
    }   
    potions.sort((a, b) => a - b)
    var res = []
    for (let i = 0; i < spells.length; i++) {
        var target = Math.ceil(success / spells[i])
        var index = binarySearch(potions, target)
        res.push(Math.max(0, potions.length - index))        
    }
    return res
}