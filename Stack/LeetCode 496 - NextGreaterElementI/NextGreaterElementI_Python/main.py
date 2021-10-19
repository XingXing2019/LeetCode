from typing import List


class Solution:
    def nextGreaterElement(self, nums1: List[int], nums2: List[int]) -> List[int]:
        res = [0] * len(nums1)
        stack = []
        map = {}
        for i in range(len(nums2)):
            while len(stack) > 0 and nums2[i] > nums2[stack[-1]]:
                map[nums2[stack.pop()]] = nums2[i]
            stack.append(i)
        for i in range(len(res)):
            res[i] = -1 if nums1[i] not in map else map[nums1[i]]
        return res
