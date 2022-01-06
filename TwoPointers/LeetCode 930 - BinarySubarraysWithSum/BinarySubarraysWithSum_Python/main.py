def numSubarraysWithSum(self, nums: List[int], goal: int) -> int:
    for i in range(1, len(nums)):
        nums[i] += nums[i - 1]
    dict = {0: 1}
    res = 0
    for num in nums:
        if num - goal in dict:
            res += dict[num - goal]
        if num not in dict:
            dict[num] = 0
        dict[num] += 1
    return res
