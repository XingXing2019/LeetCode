/**
 * @param {number[]} nums
 * @return {string}
 */
var optimalDivision = function (nums) {
    if (nums.length == 1) return nums[0].toString()
    if (nums.length == 2) return `${nums[0]}/${nums[1]}`
    var res = ''
    for (let i = 0; i < nums.length; i++) {
        res += nums[i]
        if (i != nums.length - 1) res += '/'
        if (i == 0) res += '('        
    }
    return res + ')'
}
