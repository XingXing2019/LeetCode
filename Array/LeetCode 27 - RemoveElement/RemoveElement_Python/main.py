class Solution:
    def removeElement(self, nums: List[int], val: int) -> int:
        point = 0
        for i in range(len(nums)):
            if nums[i] != val:
                nums[point] = nums[i]
                point += 1
        return point