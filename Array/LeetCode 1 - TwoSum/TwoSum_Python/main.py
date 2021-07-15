from typing import List


def twoSum(nums: List[int], target: int) -> List[int]:
    dict = {}
    for i in range(len(nums)):
        if target - nums[i] in dict:
            return [dict[target - nums[i]], i]
        else:
            dict[nums[i]] = i

