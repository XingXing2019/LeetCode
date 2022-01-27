/**
 * @param {number[]} nums
 * @return {number[]}
 */
var nextGreaterElements = function (nums) {
    var stack = []
    var map = {}
    for (let i = 0; i < 2; i++) {
        for (let j = 0; j < nums.length; j++) {
            while (stack.length != 0 && nums[j] > nums[stack[stack.length - 1]]) {
                var peek = stack.pop()
                if (map[peek]) continue
                map[peek] = j
            }
            stack.push(j)
        }      
    }
    var res = []
    for (let i = 0; i < nums.length; i++)
        res[i] = map[i] == undefined ? -1 : nums[map[i]]
    return res
}
