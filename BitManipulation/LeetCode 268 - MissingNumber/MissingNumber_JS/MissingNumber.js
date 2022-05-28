/**
 * @param {number[]} nums
 * @return {number}
 */
var missingNumber = function (nums) {
    var sum = (nums.length + 1) * nums.length / 2;
    nums.forEach(x => {
        sum -= x;
    });
    return sum;
}
