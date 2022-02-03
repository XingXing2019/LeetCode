/**
 * @param {number[]} nums1
 * @param {number[]} nums2
 * @param {number[]} nums3
 * @param {number[]} nums4
 * @return {number}
 */
var fourSumCount = function (nums1, nums2, nums3, nums4) {
    var list1 = [], list2 = []
    var map1 = {}, map2 = {}
    for (let i = 0; i < nums1.length; i++) {
        for (let j = 0; j < nums2.length; j++) {
            if (!map1[nums1[i] + nums2[j]]) {
                map1[nums1[i] + nums2[j]] = 0
                list1.push(nums1[i] + nums2[j])
            }
            map1[nums1[i] + nums2[j]]++
        }
    }
    for (let i = 0; i < nums3.length; i++) {
        for (let j = 0; j < nums4.length; j++) {
            if (!map2[nums3[i] + nums4[j]]) {
                map2[nums3[i] + nums4[j]] = 0
                list2.push(nums3[i] + nums4[j])
            }
            map2[nums3[i] + nums4[j]]++
        }        
    }
    list2.sort((a, b) => { return a - b })
    var binarySearch = function (list, target) {
        var li = 0, hi = list.length - 1
        while (li <= hi) {
            var mid = ~~((li + hi) / 2)
            if (list[mid] == target) return true
            if (list[mid] > target) hi = mid - 1
            else li = mid + 1
        }
        return false
    }
    var res = 0
    list1.forEach(num => {
        var target = num == 0 ? 0 : -num
        if (binarySearch(list2, target))
            res += map1[num] * map2[-num]
    });
    return res
}
