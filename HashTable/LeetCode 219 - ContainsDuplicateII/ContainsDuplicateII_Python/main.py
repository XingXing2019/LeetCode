class Solution:
    def containsNearbyDuplicate(self, nums: List[int], k: int) -> bool:
        dict = {}
        for i in range(len(nums)):
            if nums[i] in dict and i - dict[nums[i]] <= k:
                return True
            dict[nums[i]] = i
        return False
