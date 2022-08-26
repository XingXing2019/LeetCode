/**
 * @param {number[]} nums
 * @return {number}
 */
var maxProduct = function (nums) {
    var first = 0, second = 0
    nums.forEach(num => {
        if (num > first) {
            second = first
            first = num
        } else if (num > second)
            second = num
    });
    return (first - 1) * (second - 1)
}
