/**
 * @param {number[]} nums1
 * @param {number[]} nums2
 * @return {number[]}
 */
var nextGreaterElement = function (nums1, nums2) {
    var stack = []
    var map = {}
    for (let i = 0; i < nums2.length; i++) {
        while (stack.length != 0 && nums2[i] > nums2[stack[stack.length - 1]]) {
            var peek = stack.pop()
            map[nums2[peek]] = i
        }
        stack.push(i)
    }
    var res = []
    for (let i = 0; i < nums1.length; i++)
        res[i] = nums2[map[nums1[i]]] == undefined ? -1 : nums2[map[nums1[i]]]
    return res
}
