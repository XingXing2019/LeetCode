class Solution:
    def singleNonDuplicate(self, nums: List[int]) -> int:
        li, hi = 0, len(nums) - 1
        while li < hi:
            mid = li + (hi - li) // 2
            if mid % 2 == 0 and nums[mid] != nums[mid + 1] or mid % 2 != 0 and nums[mid] == nums[mid + 1]:
                hi = mid
            else:
                li = mid + 1
        return nums[li]
