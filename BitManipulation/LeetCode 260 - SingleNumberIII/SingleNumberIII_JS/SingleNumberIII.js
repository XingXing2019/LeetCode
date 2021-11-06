/**
 * @param {number[]} nums
 * @return {number[]}
 */
var singleNumber = function (nums) {
    var xOr = 0;
    nums.forEach(x => {
        xOr ^= x;
    });
    var flag = xOr & -xOr;
    var num1 = 0;
    nums.forEach(x => {
        if ((x & flag) != 0)
            num1 ^= x;
    });
    return [num1, xOr ^ num1];
};