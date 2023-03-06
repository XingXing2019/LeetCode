/**
 * @param {number[]} nums
 * @return {number}
 */
var findValidSplit = function (nums) {
    var getFactors = function (num) {
        var factors = []
        for (let i = 1; i <= Math.sqrt(num); i++) {
            if (num % i != 0) continue
            if (i != 1) factors.push(i)
            factors.push(num / i)
        }
        return factors
    }    
    var factors = new Array(nums.length)
    var rightMost = {}, right = 0
    for (let i = 0; i < factors.length; i++) {
        factors[i] = getFactors(nums[i])
        for (let j = 0; j < factors[i].length; j++)
            rightMost[factors[i][j]] = i
    }        
    for (let i = 0; i < factors.length - 1; i++) {
        factors[i].forEach(factor => {
            right = Math.max(right, rightMost[factor])
        })
        if (i == right) return i
    }
    return -1 
}
